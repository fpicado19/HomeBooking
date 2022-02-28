using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;

namespace ApplicationCore.Services
{
    public interface IServiceReserva
    {
        Reserva GetReservaByID(int id);
        IEnumerable<Reserva> GetReserva();
        IEnumerable<Reserva> GetReservasByCliente(int id);
        Reserva Save(Reserva reserva);
    }
}
