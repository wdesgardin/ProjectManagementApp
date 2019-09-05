using System.ComponentModel.DataAnnotations;

namespace ProjectManagementApp.Controllers.Resources
{
    public class CreateBoardResource
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}