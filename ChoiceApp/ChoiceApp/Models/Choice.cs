using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceApp.Shared.Models
{
    public class Choice
    {
        public string Id { get; set; }      
        public Option[] Options { get; set; }  
        public string Tags { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

    }
}
