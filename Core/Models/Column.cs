using System;
using System.Collections.Generic;

namespace ProjectManagementApp.Core.Models
{
    public class Column : ITrackCreateDt, ITrackEditDt
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Title { get; set; }
        public ICollection<Card> Cards { get; set; }
        public DateTime CreateDt { get; set; }
        public DateTime EditDt { get; set; }

        public Column()
        {
            Cards = new List<Card>();
        }
    }
}