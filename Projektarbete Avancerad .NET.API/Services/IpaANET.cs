using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Services
{
    public interface IpaANET<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
    }
}
