using ChoiceApp.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ChoiceApp.WebApi.Models
{
 
    public partial class Option
    {
        public Option()
        {           
        }
        public Option(ChoiceViewModel choice)
        {
            this.OptionId = Guid.NewGuid();
            this.ImageUrl = choice.ImageUrl1;
            this.Tags = choice.Tags;
            this.Name = choice.Name;
            this.CreatedDate = DateTime.Now;            
        }
  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public System.Guid OptionId { get; set; }
        
        public string ImageUrl { get; set; }
   
        public string Name { get; set; }

        public string Tags { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public string User_Id { get; set; }

       
    }
}
