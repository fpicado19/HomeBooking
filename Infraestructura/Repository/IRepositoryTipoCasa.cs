using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;

namespace Infraestructura.Repository
{
    public interface IRepositoryTipoCasa
    {
        IEnumerable<TipoCasa> GetTipoCasa();
        TipoCasa GetTipoCasaByID(int id);
        void DeleteTipoCasa(int id);
        TipoCasa Save(TipoCasa tipo);
    }
}
