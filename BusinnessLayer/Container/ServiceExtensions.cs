using BusinnessLayer.Abstract;
using BusinnessLayer.Concrate;
using BusinnessLayer.ValidationRule;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

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
                .AddErrorDescriber<CustomIdentityValidator>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IGuideService, GuideManager>();
        }

        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            services.AddScoped<ICommentDal, EFCommentDal>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();
            services.AddScoped<IAppUserDal, EFAppUserDal>();
            services.AddScoped<IReservationDal, EFReservationDal>();
            services.AddScoped<IGuideDal, EFGuideDal>();
        }
    }
}
