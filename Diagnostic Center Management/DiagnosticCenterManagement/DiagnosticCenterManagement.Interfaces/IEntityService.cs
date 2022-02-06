using System.Collections.Generic;

namespace DiagnosticCenterManagement.Interfaces
{
    public interface IEntityService<T, Tusername, Tamka>
    {
        void Add(T enity);

        T Get(Tusername username, Tamka amka);

        IEnumerable<T> GetAll();
    }
}
