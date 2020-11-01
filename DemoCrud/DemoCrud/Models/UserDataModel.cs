using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCrud.Models
{
    public class UserDataModel
    {
        public Guid pk { get; set; }
        public string name { get; set; }
        public int? age { get; set; }
        public string city { get; set; }
        public bool selected { get; set; }
    }
}