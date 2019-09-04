using System;

namespace ProjectManagementApp.Core.Models
{
    public class Card : ITrackCreateDt, ITrackEditDt
    {
        public int Id { get; set; }
        public int ColumnId { get; set; }
        public string Content { get; set; }
        public DateTime EditDt { get; set; }
        public DateTime CreateDt { get; set; }
    }
}