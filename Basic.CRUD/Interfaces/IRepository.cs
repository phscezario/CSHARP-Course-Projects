using System.Collections.Generic;

namespace Basic.CRUD.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnToId(int id);
        void Insert(T element);
        void Delete(int id);
        void Update(int id, T element);
        int  NextId(); 
    }
}