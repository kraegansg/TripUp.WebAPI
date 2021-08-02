using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Data
{
    public class Itinerary
    {
        [Key, ForeignKey(nameof(Trip))]
        public int ItineraryId { get; set; }
        public Guid OwnerId { get; set; }
        public string ItineraryName { get; set; }
        public string PitStop { get; set; }
        public int TravelDistance { get; set; }
        public DateTime TravelTime { get; set; }


        //[ForeignKey(nameof(Trip))]
        //public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

    }
}
