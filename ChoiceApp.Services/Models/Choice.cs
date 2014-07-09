using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceApp.Services.Models
{
    public class Choice
    {
        public string Id { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
      
        public DateTime CreatedDate { get; set; }
        public string Tags { get; set; }
        

        public double Lat { get; set; }
        public double Lng { get; set; }

    }
}
