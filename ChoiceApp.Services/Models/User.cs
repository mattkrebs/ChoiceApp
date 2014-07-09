using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChoiceApp.Services.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string SocialId { get; set; }
        public string LoginService { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
