namespace Crud.Contrats
{
    public interface ICrud<T> where T : class
    {
        int Create(T entity);
        bool Update(int id, T entity);
        bool Delete(int id);
        T? Get(int id);
        List<T> GetAll();
    }
}
