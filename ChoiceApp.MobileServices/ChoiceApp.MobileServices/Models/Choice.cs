using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceApp.MobileServices.Models
{
    public class Choice :Metadata
    {
        public System.Guid ChoiceId { get; set; }
        public string ChoiceName { get; set; }
        public string Tags { get; set; }
       
        public int UserId { get; set; }
        public Guid Option1Id { get; set; }
        public Guid Option2Id { get; set; }

        public virtual Option Option1 { get; set; }
        public virtual Option Option2 { get; set; }

    }
}