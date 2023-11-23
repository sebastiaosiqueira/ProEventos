using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class RedeSocialService : IRedeSocialService
    {
        private readonly IRedeSocialPersist _redeSocialPersist;
        private readonly IMapper _mapper;

        public RedeSocialService(IRedeSocialPersist redeSocialPersist, IMapper mapper){
            _redeSocialPersist = redeSocialPersist;
            _mapper = mapper;
        }

        public async Task AddRedeSocial(int Id, RedeSocialDto model, bool isEvento){
            try{

                var RedeSocial = _mapper.Map<RedeSocial>(model);
               if(isEvento){
                RedeSocial.eventoId = Id;
                RedeSocial.palestranteId = null;
                 }
               else{
                RedeSocial.eventoId = null;
                RedeSocial.palestranteId = Id;

                }
                RedeSocial.eventoId = Id;
                _redeSocialPersist.Add<RedeSocial>(RedeSocial);
                await _redeSocialPersist.SaveChangesAsync();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
        
    }

    public async Task<RedeSocialDto[]> SaveByEvento(int eventoId, RedeSocialDto[] models){
        try{
            var RedeSociais = await _redeSocialPersist.GetAllByPalestranteIdAsync(eventoId);
            if(RedeSociais == null) return null;
            foreach(var model in models){
                if(model.id==0){
                    await AddRedeSocial(eventoId, model, true);
                }
                else{
                    var RedeSocial = RedeSociais.FirstOrDefault(RedeSocial => RedeSocial.Id == model.Id);
                    model.eventoId = eventoId;

                    _mapper.Map<model.RedeSocial);
                    _redeSocialPersit.Update<RedeSocial> (RedeSocial);
                    await _redeSocialPersist.SaveChangesAsync();
                }
            }

            var RedeSocialRetorno = await _redeSocialPersist.GetAllByEventoIdAsync(eventoId);
            return _mapper.Map<RedeSocialDto[]>(RedeSocialRetorno);
        }
        catch(Execption ex){
            throw new Exception(ex.Message);
        }
    }


        public async Task<RedeSocialDto[]> SaveByPalestrante(int palestranteId, RedeSocialDto[] models){
        try{
            var RedeSociais = await _redeSocialPersist.GetAllByPalestranteIdAsync(palestranteId);
            if(RedeSociais == null) return null;
            foreach(var model in models){
                if(model.id==0){
                    await AddRedeSocial(palestranteId, model, false);
                }
                else{
                    var RedeSocial = RedeSociais.FirstOrDefault(RedeSocial => RedeSocial.Id == model.Id);
                    model.palestranteId = palestranteId;

                    _mapper.Map<model.RedeSocial);
                    _redeSocialPersit.Update<RedeSocial> (RedeSocial);
                    await _redeSocialPersist.SaveChangesAsync();
                }
            }

            var RedeSocialRetorno = await _redeSocialPersist.GetAllByEventoIdAsync(palestranteId);
            return _mapper.Map<RedeSocialDto[]>(RedeSocialRetorno);
        }
        catch(Execption ex){
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteByEvento(int eventoId, int RedeSocialId){
        try{
            var RedeSocial = await _redeSocialPersist.GetRedeSocialEventoByIdasync(eventoId, redeSocialId);
            if(RedeSocial ==null) throw new Exception("Rede Social por Evento para delete não encontrado");
            _redeSocialPersist.Delete<RedeSocial>(RedeSocial);
            return await _redeSocialPersist.SaveChangesAsync();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }

    }

        public async Task<bool> DeleteByPalestrante(int palestranteId, int RedeSocialId){
        try{
            var RedeSocial = await _redeSocialPersist.GetRedeSocialEventoByIdasync(palestranteId, redeSocialId);
            if(RedeSocial ==null) throw new Exception("Rede Social por palestrante para delete não encontrado");
            _redeSocialPersist.Delete<RedeSocial>(RedeSocial);
            return await _redeSocialPersist.SaveChangesAsync();
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }

    }

    public async Task<RedeSocialDto[]> GetAllByEventoIdAsync(int eventoId){
        try{
            var RedeSociais = await _redeSocialPersist.GetAllByEventoIdAsync(eventoId);
            if(RedeSociais == null) return null;
            var resultado = _mapper.Map<RedeSocialDto[]>(RedeSociais);
            return resultado;
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
        }

           public async Task<RedeSocialDto[]> GetAllByPalestranteIdAsync(int palestranteId){
        try{
            var RedeSociais = await _redeSocialPersist.GetAllByEventoIdAsync(palestranteId);
            if(RedeSociais == null) return null;
            var resultado = _mapper.Map<RedeSocialDto[]>(RedeSociais);
            return resultado;
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }
        }


        public async Task<RedeSocialDto>  GetRedeSocialEventoByIdsAsync(int eventoId, int redeSocialId){
            try{
                var RedeSocial = await _redeSocialPersist.GetRedeSocialByIdsAsync(eventoId , redeSocialId){
                    if(RedeSocial == null) return null;
                    var resultado = _mapper.Map<RedeSocialDto>(RedeSocial);
                    return resultado;
                }
                catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<RedeSocialDto>  GetRedeSocialPalestranteByIdsAsync(int palestranteId, int redeSocialId){
            try{
                var RedeSocial = await _redeSocialPersist.GetRedeSocialByIdsAsync(palestranteId , redeSocialId){
                    if(RedeSocial == null) return null;
                    var resultado = _mapper.Map<RedeSocialDto>(RedeSocial);
                    return resultado;
                }
                catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }
        }
    }