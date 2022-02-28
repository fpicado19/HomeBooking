using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public interface IRepositoryServicio
    {
        IEnumerable<TipoServicio> GetServicio();
        TipoServicio GetServicioByID(int ID);
        void DeleteServicio(int ID);
        TipoServicio Save(TipoServicio servicio);
    }
}
