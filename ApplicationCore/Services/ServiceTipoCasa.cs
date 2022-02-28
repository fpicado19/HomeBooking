using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;
using Infraestructura.Repository;

namespace ApplicationCore.Services
{
    public class ServiceTipoCasa : IServiceTipoCasa
    {

        public void DeleteTipoCasa(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoCasa> GetTipoCasa()
        {
            IRepositoryTipoCasa repository = new RepositoryTipoCasa();
            return repository.GetTipoCasa();
        }

        public TipoCasa GetTipoCasaByID(int id)
        {
            throw new NotImplementedException();
        }

        public TipoCasa Save(TipoCasa tipo)
        {
            throw new NotImplementedException();
        }
    }
}
