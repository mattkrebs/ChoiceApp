using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using ChoiceApp.MobileServices.DataObjects;
using ChoiceApp.MobileServices.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using AutoMapper;

namespace ChoiceApp.MobileServices
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));
            
            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<Choice, MobileChoice>()
                    .ForMember(dst => dst.Id, map => map.MapFrom(x => x.Id))
                    .ForMember(dst => dst.ChoiceName, map => map.MapFrom(x => x.ChoiceName))
                    .ForMember(dst => dst.Tags, map => map.MapFrom(x => x.Tags))
                    .ForMember(dst => dst.CreatedAt, map => map.MapFrom(x => x.CreatedAt))
                    .ForMember(dst => dst.UpdatedAt, map => map.MapFrom(x => x.UpdatedAt))                    
                    .ForMember(dst => dst.Version, map => map.MapFrom(x => x.Version));



                cfg.CreateMap<Option, MobileOption>()
                    .ForMember(dst => dst.Id, map => map.MapFrom(x => x.Id))
                    .ForMember(dst => dst.Name, map => map.MapFrom(x => x.OptionName))
                    .ForMember(dst => dst.Tags, map => map.MapFrom(x => x.Tags))
                    .ForMember(dst => dst.ImageUrl, map => map.MapFrom(x => x.ImageUrl))
                    .ForMember(dst => dst.CreatedAt, map => map.MapFrom(x => x.CreatedAt))
                    .ForMember(dst => dst.UpdatedAt, map => map.MapFrom(x => x.UpdatedAt))
                    .ForMember(dst => dst.Version, map => map.MapFrom(x => x.Version));


            });



            Database.SetInitializer(new MobileServicesInitializer());


            

        }
    }

    public class MobileServicesInitializer : DropCreateDatabaseIfModelChanges<ChoiceContext>
    {
        protected override void Seed(ChoiceContext context)
        {
            //List<TodoItem> todoItems = new List<TodoItem>
            //{
            //    new TodoItem { Id = "1", Text = "First item", Complete = false },
            //    new TodoItem { Id = "2", Text = "Second item", Complete = false },
            //};

            //foreach (TodoItem todoItem in todoItems)
            //{
            //    context.Set<TodoItem>().Add(todoItem);
            //}

            base.Seed(context);
        }
    }
}

