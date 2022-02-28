using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;
using Infraestructura.Repository;

namespace ApplicationCore.Services
{
    public class ServiceReserva : IServiceReserva
    {
        public IEnumerable<Reserva> GetReserva()
        {
            IRepositoryReserva repositoryReserva = new RepositoryReserva();
            return repositoryReserva.GetReserva();
        }

        public Reserva GetReservaByID(int id)
        {
            IRepositoryReserva repositoryReserva = new RepositoryReserva();
            return repositoryReserva.GetReservaByID(id);
        }

        public Reserva Save(Reserva reserva)
        {
            IRepositoryReserva repositoryReserva = new RepositoryReserva();
            return repositoryReserva.Save(reserva);
        }
        public IEnumerable<Reserva> GetReservasByCliente(int id)
        {
            IRepositoryReserva repositoryReserva = new RepositoryReserva();
            return repositoryReserva.GetReservasByCliente(id);
        }
    }
}
