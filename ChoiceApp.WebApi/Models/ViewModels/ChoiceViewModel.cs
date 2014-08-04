using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceApp.WebApi.Models.ViewModels
{
    public class ChoiceViewModel
    {
        public string Name { get; set; }
        public string Tags { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }



        public Option Option1
        {
            get
            {
                if (String.IsNullOrWhiteSpace(ImageUrl1))
                    return null;

                return new Option()
                {
                    
                    CreatedDate = DateTime.Now,
                    ImageUrl = ImageUrl1,
                    Name = this.Name,
                    OptionId = Guid.NewGuid(),
                    Tags = this.Tags,
                };
            }
        }
        public Option Option2
        {
            get
            {
                if (String.IsNullOrWhiteSpace(ImageUrl2))
                    return null;

                return new Option()
                {                    
                    CreatedDate = DateTime.Now,
                    ImageUrl = ImageUrl2,
                    Name = this.Name,
                    OptionId = Guid.NewGuid(),
                    Tags = this.Tags,
                };
            }
        }

    }
}