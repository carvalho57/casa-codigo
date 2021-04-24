using System;
using System.Threading.Tasks;
using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface IStateRepository
    {
        void Add(State state);
        Task<bool> StateExist(State state);
        Task<State> GetStateById(Guid state, bool include = false);
    }
}