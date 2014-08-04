using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System;

namespace ChoiceWeb.Models
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
        protected override void Seed(ChoiceContext context)
        {
            var options = new List<Option>{
                new Option {  ImageUrl="Image Url Here", Name="Search Term or Text", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="Image Url Here", Name="Search Term or Text", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="Image Url Here", Name="Search Term or Text", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="Image Url Here", Name="Search Term or Text", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="Image Url Here", Name="Search Term or Text", CreatedDate= DateTime.Now},
                new Option {  ImageUrl="Image Url Here", Name="Search Term or Text", CreatedDate= DateTime.Now},
            };
            foreach (var item in options)
            {
                context.Options.Add(item);
                context.SaveChanges();
            }


            var savedOptions = context.Options.ToListAsync().Result;

            var choices = new List<Choice>{
                 new Choice{Name="Cool Choice", Tags="test", Option1Id = savedOptions[0].ChoiceOptionId, Option2Id= savedOptions[1].ChoiceOptionId, CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice2", Tags="test", Option1Id = savedOptions[2].ChoiceOptionId, Option2Id= savedOptions[3].ChoiceOptionId, CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice3", Tags="test", Option1Id = savedOptions[4].ChoiceOptionId, Option2Id= savedOptions[5].ChoiceOptionId, CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice4", Tags="test", Option1Id = savedOptions[1].ChoiceOptionId, Option2Id= savedOptions[3].ChoiceOptionId, CreatedDate=DateTime.Now },
                 new Choice{Name="Cool Choice5", Tags="test" , Option1Id = savedOptions[0].ChoiceOptionId, Option2Id= savedOptions[2].ChoiceOptionId, CreatedDate=DateTime.Now},
                 new Choice{Name="Cool Choice6", Tags="test", Option1Id = savedOptions[4].ChoiceOptionId, Option2Id= savedOptions[5].ChoiceOptionId, CreatedDate=DateTime.Now },

            };
            foreach (var item in choices)
            {
                context.Choices.Add(item);
                context.SaveChanges();
            }


        }


    }
}
