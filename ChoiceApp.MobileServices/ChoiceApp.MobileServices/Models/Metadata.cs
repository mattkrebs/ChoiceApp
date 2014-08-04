using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceApp.MobileServices.Models
{
    public class Metadata
    {
        public DateTimeOffset? CreatedAt { get; set; }
        
        public bool Deleted { get; set; }
       
        public string Id { get; set; }
      
        public DateTimeOffset? UpdatedAt { get; set; }
      
        public byte[] Version { get; set; }
    }
}