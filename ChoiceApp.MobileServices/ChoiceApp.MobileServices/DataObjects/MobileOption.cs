using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceApp.MobileServices.DataObjects
{
    public class MobileOption : EntityData
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }

    }
}