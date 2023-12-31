﻿using BusinnessLayer.Abstract;
using BusinnessLayer.Abstract.AbstractUow;
using BusinnessLayer.Concrate;
using BusinnessLayer.Concrate.ConcreteUow;
using BusinnessLayer.ValidationRule;
using BusinnessLayer.ValidationRule.AnnouncementValidationRules;
using BusinnessLayer.ValidationRule.ContactUs;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BusinnessLayer.Container
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<Context>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PdfManager>();
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IContactUsService, ContactUsManager>();
        }

        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            services.AddScoped<ICommentDal, EFCommentDal>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();
            services.AddScoped<IAppUserDal, EFAppUserDal>();
            services.AddScoped<IReservationDal, EFReservationDal>();
            services.AddScoped<IGuideDal, EFGuideDal>();
            services.AddScoped<IContactUsDal, EFContactUsDal>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();
            services.AddScoped<IAccountDal, EFAccountDal>();
            services.AddScoped<ICommentDal, EFCommentDal>();
            services.AddScoped<IContactUsDal, EFContactUsDal>();

            services.AddScoped<IUnitOfWorkDal, UowDal>();
        }

        public static void ConfigureLogging(this IServiceCollection services)
        {
            ILoggerFactory loggerFactory = new LoggerFactory();

            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });

            var path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");
        }

        public static void ConfigureValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddScoped<IValidator<AnnouncementAddDto>, AnnouncementValidator>();
            services.AddScoped<IValidator<AnnouncementUpdateDto>, AnnouncementUpdateValidator>();
            services.AddScoped<IValidator<SendMessageDto>, SendContactUsValidator>();
        }
    }
}
