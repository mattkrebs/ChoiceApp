using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChoiceApp.Services.Models
{
    public class Option
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public string  ImageUrl { get; set; }

    }
}
