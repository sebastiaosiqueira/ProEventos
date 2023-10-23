using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }   
        public string Local { get; set; }   
        public DateTime? DataEvento { get; set; } 
        [Required(ErrorMessage = " O Campo {0} é obrigatório."),
        MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caracteres."),
        MaxLength(50, ErrorMessage = "{0} deve ter no máxmo 50 caracteres.")]
        public string Tema{get; set; }
        [Range(1,120000, ErrorMessage="{0} não pode ser menor que 1 e maior que 120.000.")]
        public int QtdPessoas{get; set; }   
        public string Lote{get; set; }
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage="Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemURL  { get; set; }
        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [Phone(ErrorMessage ="o campo {0} está com o numero inválido.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [EmailAddressAttribute(ErrorMessage = "O campo {0} precisa ser um e-mail válido")]
        public string Email {get;set;}

        public IEnumerable<LoteDto> Lotes{get;set;}
        public IEnumerable<RedeSocialDto> RedeSociais{get;set;}
        public IEnumerable<PalestranteDto> Palestrantes{get;set;}
       
        
    }
}