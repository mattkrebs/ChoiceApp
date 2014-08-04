using System;
using System.Collections.Generic;

namespace ChoiceWeb.Models
{
    public partial class User
    {
        public User()
        {
            this.Choices = new List<Choice>();
        }

        public int UserId { get; set; }
        public string SocialId { get; set; }
        public string LoginService { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
    }
}
