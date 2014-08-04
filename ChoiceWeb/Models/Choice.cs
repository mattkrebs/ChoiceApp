using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChoiceWeb.Models
{
    public partial class Choice
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public System.Guid ChoiceId { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public Guid Option1Id { get; set; }
        public Guid Option2Id { get; set; }

        public virtual Option Option1 { get; set; }
        public virtual Option Option2 { get; set; }

    }
}
