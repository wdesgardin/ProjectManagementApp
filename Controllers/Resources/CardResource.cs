namespace ProjectManagementApp.Controllers.Resources
{
    public class CardResource : TimeStampedResource
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}