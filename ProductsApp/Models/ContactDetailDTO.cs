using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApp.Models
{
    public class ContactDetailDTO
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        //Navigation Property
        public ICollection<Deal> Deals { get; set; }
    }
}