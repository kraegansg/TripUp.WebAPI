using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Data
{
    public class Pack
    {
        [Key, ForeignKey(nameof(Trip))]
        public int PackId { get; set; }
        public Guid OwnerId { get; set; }
        public string PackName { get; set; }
        public string Clothes { get; set; }
        public string BathItems { get; set; }
        public string Essentials { get; set; }
        public string Other { get; set; }


        //[ForeignKey(nameof(Trip))]
        //public int TripId { get; set; }
        public virtual Trip Trip { get; set; }


    }
}