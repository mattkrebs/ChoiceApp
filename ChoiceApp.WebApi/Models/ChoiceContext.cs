using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChoiceApp.WebApi.Models
{
    public partial class ChoiceContext : IdentityDbContext<ApplicationUser>
    {
        static ChoiceContext()
        {
            Database.SetInitializer<ChoiceContext>(new ChoiceInitilizer());
        }

        public ChoiceContext()
            : base("Name=ChoiceContext")
        {
        }

        public static ChoiceContext Create()
        {
            return new ChoiceContext();
        }

        public DbSet<Choice> Choices { get; set; }
        public DbSet<Option> Options { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class ChoiceInitilizer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ChoiceContext>
    {
        protected override void Seed(ChoiceContext context){
            var options = new List<Option>{
                new Option {  ImageUrl="https://i.imgflip.com/aocvv.jpg", Name="LOLCats", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="http://i.imgur.com/pKIoyDr.jpg", Name="LOLCats", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="http://i.imgur.com/PJC66oT.png", Name="LOLCats", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="http://i.imgur.com/Cuwy6wZ.jpg", Name="LOLCats", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="http://i.imgur.com/q8QTjbg.jpg", Name="LOLCats", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="http://imgur.com/OxjtAiU", Name="LOLCats", CreatedDate= DateTime.Now},
            };
            

            var choices = new List<Choice>{
                 new Choice{Name="Cool Choice", Tags="test", Option1 = options[0], Option2= options[1], CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice", Tags="test", Option1 = options[1], Option2= options[2], CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice", Tags="test", Option1 = options[2], Option2= options[3], CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice", Tags="test", Option1 = options[3], Option2= options[4], CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice", Tags="test", Option1 = options[4], Option2= options[5], CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice", Tags="test", Option1 = options[5], Option2= options[0], CreatedDate=DateTime.Now }
            };
            foreach (var item in choices)
            {
                context.Choices.Add(item);
                context.SaveChanges();
            }
          

        }
        
       
    }
}
