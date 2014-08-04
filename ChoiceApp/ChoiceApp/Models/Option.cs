﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChoiceApp.Shared.Models
{
    public class Option
    {
        public System.Guid OptionId { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Tags { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public string User_Id { get; set; }

    }
}
