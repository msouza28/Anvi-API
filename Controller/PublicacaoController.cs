using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Data;
using Anvi_API.Dtos.imagem;
using Anvi_API.Dtos.publicacao;
using Anvi_API.Mappers;
using Anvi_API.Models;
using Anvi_API.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Anvi_API.Controller
{
    [ApiController]
    [Route("v1/api/publicacao")]
    public class PublicacaoController(IPublicacaoRepository publicacaoRepository, IUsuarioRepository usuarioRepository) : ControllerBase
    {
        private readonly IPublicacaoRepository _publicacaoRepository = publicacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllPublicaoes(){
           var publicacoes = await _publicacaoRepository.GetAllPublicacao();
           var publicacaoDto = publicacoes.Select(s => s.ToPublicacaoDto());
            return Ok(publicacaoDto);
        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id){
            var publicacaoById = await _publicacaoRepository.GetByIdAsync(id);
            if(publicacaoById == null){
                return NotFound("A publicação com ID:" + id + " não existe.");
            }
            return Ok(publicacaoById.ToPublicacaoDto());
        }

        [HttpGet()]
        [Route("usuario/{Id:long}")]
        public async Task<IActionResult> GetAllByUsuarioId([FromRoute] long Id){
            var publicacaoById = await _publicacaoRepository.GetAllByUsuarioId(Id);
            if(publicacaoById == null){
                return NotFound($"Não há publicações para esse usuário");
            }
            var publicacaoDto = publicacaoById.Select(s => s.ToPublicacaoDto());
            return Ok(publicacaoDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublicacao([FromBody] CreatePublicacaoRequestDto requestDto){
            
            var usuarioById = await _usuarioRepository.GetUsuarioByIdAsync(requestDto.UsuarioId);
            if(usuarioById == null){
                return NotFound("Usuário não encontrado.");
            }

            var publicacao = await _publicacaoRepository.CreatePublicacaoAsync(requestDto);

            return CreatedAtAction(nameof(GetById), new {id = publicacao.Id}, publicacao.ToPublicacaoDto());
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdatePublicacao([FromRoute] long id, [FromBody] UpdatePublicacaoRequestDto requestDto){
                var pubicacoById = await _publicacaoRepository.UpdatePublicacaoAsync(id, requestDto);
                if(pubicacoById == null) {
                    return NotFound($"Publicação com ID: {id} não encontrada.");
                }

            return CreatedAtAction(nameof(GetById), new {id = pubicacoById.Id}, pubicacoById.ToPublicacaoDto());;
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeletePublicacao([FromRoute] long id){
            var publicacaoById = await _publicacaoRepository.DeleteById(id);
            if(publicacaoById == null){
                return NotFound("Publicação com ID: " + id + " não existe.");
            }
            return NoContent();
        }
    }
}