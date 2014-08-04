using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChoiceWeb.Models
{
    public partial class Option
    {
        public Option()
        {           
        }

        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public System.Guid ChoiceOptionId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
