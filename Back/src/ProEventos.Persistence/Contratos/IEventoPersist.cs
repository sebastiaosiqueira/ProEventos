using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
      public interface IEventoPersist
    {
        Task<PageList<ProEventos>> GetAllEventosByTemaAsync(int userId, PageParams pageParams, string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false);
    }
}