using DAL.Entities.CoomonModel;

namespace DAL.Presistance.Repo._Genaric
{
    public interface IGenaricRepository<T> where T : ModelBase
    {

        IQueryable<T> GetIqueryable(bool WithNoTaraKing = false);
        IEnumerable<T>GetAll(bool WithNoTaraKing = false);  
        T? Get(int? IdItem);
        int Add(T Item);
        int Update(T Item);
        int Delete(T Item);


    }
}
