using EntityLayer.Concrete;

namespace BusinnessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        AppUser FindByUserName(string name);
    }
}
