using DAL.Entities.CoomonModel;
using DAL.Presistance.DATA.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Presistance.Repo._Genaric
{
    public class GenaricRepository<T>: IGenaricRepository<T> where T : ModelBase
    {
      
            private protected readonly ApplicationDbContext _aplacationDebcontext;

            public GenaricRepository(ApplicationDbContext aplacationDebcontext)
            {
                this._aplacationDebcontext = aplacationDebcontext;
            }

            public int Add(T department)
            {
                _aplacationDebcontext.Set<T>().Add(department);
                return SaveChanges();
            }

            public int Delete(T department)
            {
                _aplacationDebcontext.Set<T>().Remove(department);
                return SaveChanges();


            }

      
      
        public T? Get(int? IdOfDepartment)

         //=> _aplacationDebcontext.Departments.FirstOrDefault(D => D.Id == IdOfDepartment);
         //=> _aplacationDebcontext.Departments.Local.FirstOrDefault(D => D.Id == IdOfDepartment);
         => _aplacationDebcontext.Set<T>().Find(IdOfDepartment);//TackAraay Of Prames =>param,pram,

            public IEnumerable<T> GetAll(bool WithNoTracking = false)
            {
                if (WithNoTracking)
                {
                    return _aplacationDebcontext.Set<T>().AsNoTracking().ToList();
                }

                return _aplacationDebcontext.Set<T>().ToList();
            }

        public IQueryable<T> GetIqueryable(bool WithNoTaraKing = false)
        {
            if (WithNoTaraKing)
            {
                return _aplacationDebcontext.Set<T>().AsNoTracking();
            }

            return _aplacationDebcontext.Set<T>();
        }

        public int Update(T department)
            {
                _aplacationDebcontext.Set<T>().Update(department);
                return SaveChanges();

            }
            private int SaveChanges()
            {
                return _aplacationDebcontext.SaveChanges();//Change State Of Object From Change Traker

            }
        }
}



