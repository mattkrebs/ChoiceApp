using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceApp.MobileServices.Models
{
    public class Option : Metadata
    {
        public System.Guid OptionId { get; set; }
        public string ImageUrl { get; set; }
        public string OptionName { get; set; }
        public string Tags { get; set; }
       
        public int UserId { get; set; }
    }
}