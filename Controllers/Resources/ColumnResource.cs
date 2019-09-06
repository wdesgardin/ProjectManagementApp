namespace ProjectManagementApp.Controllers.Resources
{
    public class ColumnResource : TimeStampedResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MyProperty { get; set; }
    }
}