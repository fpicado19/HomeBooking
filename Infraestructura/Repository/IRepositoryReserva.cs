using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;

namespace Infraestructura.Repository
{
   public interface IRepositoryReserva
    {
        Reserva GetReservaByID(int id);
        IEnumerable<Reserva> GetReservasByCliente(int id);
        IEnumerable<Reserva> GetReserva();
        Reserva Save(Reserva reserva);
    }
}
