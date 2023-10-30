using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
      public interface ILotePersist
    {
       /// <summary>
       /// Método que retornará uma lista de lotes por eventoId
       /// </summary>
       /// <param name="eventoId">codigo chave do evento</param>
       /// <returns>Lista de lotes</returns>
        Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);
        /// <summary>
        /// Método que get que retornará apenas 1 lote
        /// </summary>
        /// <param name="eventoId">codigo da chave da tabela evento</param>
        /// <param name="Id">codigo chave da tabela  lote</param>
        /// <returns>returna somente um lote</returns> <summary>
        /// 
        /// </summary>
        Task<Lote> GetLoteByIdsAsync(int eventoId, int Id);
    }
}