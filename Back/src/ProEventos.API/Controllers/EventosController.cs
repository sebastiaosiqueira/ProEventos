using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Dtos;
using ProEventos.Application.Contratos;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;


namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
       
        private readonly IEventoService _eventoService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public EventosController(IEventoService eventoService, IWebHostEnvironment hostEnviroment){ _eventoService = eventoService; _hostEnviroment = hostEnviroment;}

        [HttpGet]
        public async Task<IActionResult>  Get()
        {
           try
           {
            var eventos = await _eventoService.GetAllEventosAsync(true);

            if(eventos == null) return NoContent();

            return Ok(eventos);
           }
           catch (Exception ex)
           {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
           }
        
        }
         [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
           try{
            var evento = await _eventoService.GetEventoByIdAsync(id, true);
            if(evento==null) return NotFound("Evento por Id não encontrado.");
            return Ok(evento);
           }
           catch(Exception ex){
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento. Erro: {ex.Message}");

           }
        
        }

           [HttpGet("tema/tema")]
        public async Task<IActionResult> GetById(string tema)
        {
           try{
            var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if(evento==null) return NotFound("Eventos por tema não encontrados.");
            return Ok(evento);
           }
           catch(Exception ex){
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento. Erro: {ex.Message}");

           }
        
        }

        
        [HttpPost("upload-image/{eventoId}")]
        public async Task<IActionResult> UploadImage(int eventoId){
            
            try
            {
            var evento = await _eventoService.GetEventoByIdAsync(eventoId, true);
            if(evento == null) return NoContent();
              
              var file =Request.Form.Files[0];
              if(file.Length>0){
               //delete a image
               DeleteImage(evento.ImagemURL);
               //evento imagmurl = save image(file)
               evento.ImagemURL = await SaveImage(file);
              }
            var EventoRetorno = await _eventoService.UpdateEvento(eventoId, evento);
            return Ok(EventoRetorno);
            }
            catch(Exception ex){
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento. Erro: {ex.Message}");

           }
        
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model){
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
            var evento = await _eventoService.AddEventos(model);
            if(evento==null) return BadRequest("Erro ao tentar adicionar evento.");
            return Ok(evento);
           }
           catch(Exception ex){
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento. Erro: {ex.Message}");

           }
        }

         [HttpPut("id")]
         public async Task<IActionResult> Put(int id, EventoDto model ){
           try
           {
            var evento = await _eventoService.UpdateEvento(id, model );
            if(evento == null) return BadRequest("Erro ao tentar realizar update do evento");
            return Ok(evento);
           
           }
           catch (Exception ex)
           {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar evento.{ex.Message}");
           }
        }

        
         [HttpDelete("id")]
         public async Task<IActionResult> Delete(int id){
           try
           {
            return await _eventoService.DeleteEvento(id) ?
             Ok(new{message ="Deletado"}) :
              BadRequest("Evento não deletado.");
            
           }
           catch (Exception ex )
           {
            
           return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o evento. Erro{ex.Message}");
           }
        }

          [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile){
             string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                                              .Take(10)
                                              .ToArray()
                                         ).Replace(' ', '-');
         imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";
         
         var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images", imageName);
         using (var fileStream = new FileStream(imagePath, FileMode.Create)){
            await imageFile.CopyToAsync(fileStream);
         }
         return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName){
         var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images", imageName);
         if(System.IO.File.Exists(imagePath))
         System.IO.File.Delete(imagePath);
        }
    }

    
}
