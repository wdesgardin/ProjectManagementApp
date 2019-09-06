using System.ComponentModel.DataAnnotations;

namespace ProjectManagementApp.Controllers.Resources
{
    public class CreateColumnResource
    {
        [Required]
        public string Title { get; set; }
    }
}