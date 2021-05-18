using System.Collections.Generic;
using Business.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IDEARepository : IRepository<DEA>
    {
        DEA GetById(int id);

        IList<DEA> GetAll();

        DEA GetByCodigo(string codigo);
    }
}