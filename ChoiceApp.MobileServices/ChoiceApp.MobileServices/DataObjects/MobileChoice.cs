using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations;

namespace ChoiceApp.MobileServices.DataObjects
{
    public class MobileChoice : EntityData
    {
        
        public string ChoiceName { get; set; }
        public string Tags { get; set; }
        [Required]
        public string Option1Id { get; set; }
        [Required]
        public string Option2Id { get; set; }

    }
}