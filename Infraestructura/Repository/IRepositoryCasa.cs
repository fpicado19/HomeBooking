using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;

namespace Infraestructura.Repository
{
    public interface IRepositoryCasa
    {
        Casa GetCasaByID(int id);
        Casa Save(Casa casa);
        void DeleteCasa(int id);
        IEnumerable<Casa> GetCasas();
        IEnumerable<Casa> GetTipoCasa(int idTCasa);
    }
}
