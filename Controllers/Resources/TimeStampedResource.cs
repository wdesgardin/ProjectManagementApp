using System;

namespace ProjectManagementApp.Controllers.Resources
{
    public abstract class TimeStampedResource
    {
        public DateTime CreateDt { get; set; }
        public DateTime EditDt { get; set; }
    }
}