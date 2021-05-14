
using System.ComponentModel.DataAnnotations;
namespace MVC_NHL.Models.DataTransferObjects
{
    public class CreateTeamDTO
    {
        [Required(ErrorMessage ="Please type into Team Name")]
        [MinLength(3, ErrorMessage = "Minimum length must be 3")]
        [DataType(DataType.Text)]
        public string TeamName{ get; set; }
      
        [Required(ErrorMessage = "Please type into Description")]
        [MinLength(3, ErrorMessage = "Minimum length must be 3")]
        [DataType(DataType.Text)]
        public string Description{ get; set; }
    }
}