using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApp.Models
{
    public class LocationDetailDTO
    {
        public int LocationId { get; set; }
        public string City { get; set; }


        //Navigation Property
        public ICollection<Deal> Deals { get; set; }
    }
}