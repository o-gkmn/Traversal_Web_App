using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public void ChangeToFalseByGuide(int id)
        {
            using Context context = new Context();
            var values = context.Guides.Find(id);
            values.Status = false;
            context.Update(values);
            context.SaveChanges();
        }

        public void ChangeToTrueByGuide(int id)
        {
            using Context context = new Context();
            var values = context.Guides.Find(id);
            values.Status = true;
            context.Update(values);
            context.SaveChanges();
        }
    }
}
