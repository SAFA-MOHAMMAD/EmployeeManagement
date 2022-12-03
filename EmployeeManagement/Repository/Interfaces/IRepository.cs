namespace EmployeeManagement.Repository.Interfaces
{
    public interface IRepository <TEntity>
    {
        TEntity GetById (int id);
        List<TEntity> GetAll ();
        TEntity add(TEntity entity);
        TEntity Update (TEntity entityChange);    
        TEntity EntityDelete (int id);
        IList<TEntity> Search(string term);
    }

}
