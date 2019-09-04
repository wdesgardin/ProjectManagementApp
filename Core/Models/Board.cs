using System;
using System.Collections.Generic;

namespace ProjectManagementApp.Core.Models
{
    public class Board : ITrackCreateDt, ITrackEditDt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Column> Columns { get; set; }
        public DateTime CreateDt { get; set; }
        public DateTime EditDt { get; set; }

        public Board()
        {
            Columns = new List<Column>();
        }
    }
}