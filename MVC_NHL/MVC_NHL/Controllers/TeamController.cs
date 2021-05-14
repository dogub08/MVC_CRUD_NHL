using MVC_NHL.Models.DataTransferObjects;
using MVC_NHL.Models.ORM.Context;
using MVC_NHL.Models.ORM.Entities.Abstract;
using MVC_NHL.Models.ORM.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NHL.Controllers
{
    public class TeamController : Controller
    {
        public ApplicationDbContext _dbContext;
        public TeamController() => _dbContext = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost] 
        public ActionResult Create(CreateTeamDTO data)
        {
            if (ModelState.IsValid) 
            {
                Team team = new Team();
                team.TeamName = data.TeamName;
                team.Description = data.Description;
                _dbContext.Teams.Add(team);
                _dbContext.SaveChanges();
                ViewBag.TransactionStatus = 1;
                return View();
            }
            else {
                ViewBag.TransactionStatus = 2;
                return View(data); 
            }
        }

        public ActionResult List()
        {
            List<Team> teamList = _dbContext.Teams.Where(x => x.Status != Status.Passive).ToList();
            return View(teamList);
        }
        public ActionResult Update(int id)
        {
            Team team = _dbContext.Teams.FirstOrDefault(x => x.Id == id);
            if (team!=null)
            {
                UpdateTeamDTO data = new UpdateTeamDTO();
                data.Id = team.Id;
                data.TeamName= team.TeamName;
                data.Description= team.Description;
                return View(data);
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult Update(UpdateTeamDTO data)
        {
            if (ModelState.IsValid)
            {
                Team team = _dbContext.Teams.FirstOrDefault(x => x.Id == data.Id);
                team.TeamName = data.TeamName;
                team.Description = data.Description;
                team.UpdateDate = DateTime.Now;
                team.Status = Status.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View(data);
            }
        }
        public ActionResult Delete(int id)
        {
            Team team = _dbContext.Teams.Find(id);
            if (team!=null)
            {
                team.Status = Status.Passive;
                team.DeleteDate = DateTime.Now;
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }
        }
    }
}