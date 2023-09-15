using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
        public int PalestranteId{get;set;}
        public PalestranteEvento Palestrante{get;set;}
        public int EventoId {get;set;}
        public Evento Evento{get;set;}
    }
}