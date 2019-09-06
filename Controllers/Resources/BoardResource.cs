namespace ProjectManagementApp.Controllers.Resources
{
    public class BoardResource : TimeStampedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}