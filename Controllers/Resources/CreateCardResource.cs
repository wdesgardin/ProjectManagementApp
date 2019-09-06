using System.ComponentModel.DataAnnotations;

namespace ProjectManagementApp.Controllers.Resources
{
    public class CreateCardResource
    {
        [Required]
        public string Content { get; set; }
    }
}