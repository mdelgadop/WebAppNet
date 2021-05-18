using System.Collections.Generic;
using Business.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IMunicipioRepository : IRepository<Municipio>
    {
        Municipio GetById(int id);

        IList<Municipio> GetAll();

        Municipio GetByCodigo(string codigo);
    }
}