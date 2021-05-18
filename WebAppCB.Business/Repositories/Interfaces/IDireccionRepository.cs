using System.Collections.Generic;
using Business.Entities;

namespace Business.Repositories.Interfaces
{
    public interface IDireccionRepository : IRepository<Direccion>
    {
        Direccion GetById(int id);

        IList<Direccion> GetAll();
    }
}