using Infraestructura.Models;
using Infraestructura.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceServicio : IServiceServicio
    {
        public void DeleteServicio(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoServicio> GetServicio()
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.GetServicio();
        }

        public TipoServicio GetServicioByID(int ID)
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.GetServicioByID(ID);
        }

        public TipoServicio Save(TipoServicio servicio)
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.Save(servicio);
        }
    }
}
