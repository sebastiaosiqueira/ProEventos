using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Models
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int TotalPages) 
        {
            this.CurrentPage = currentPage;
            this.itemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
            this.TotalPages = TotalPages;
          
   
        }
                public int CurrentPage{get;set;}
        public int itemsPerPage{get;set;}
        public int TotalItems{get;set;}
        public int TotalPages{get;set;}
        
    }
}