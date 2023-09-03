namespace DataAccessLayer.Abstract
{
    public interface IGenericUowDal<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        T GetById(int id);
        void MultiUpdate(List<T> t);
    }
}
