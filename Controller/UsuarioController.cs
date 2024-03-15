using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Data;
using Anvi_API.Dtos.usuario;
using Anvi_API.Mappers;
using Anvi_API.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anvi_API.Controller
{
    [ApiController]
    [Route("v1/api/usuario")]
    public class UsuarioController(IUsuarioRepository usuarioRepository) : ControllerBase
    {
       
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
            var usuarioDto = usuarios.Select(u => u.ToUsuarioDto());
            return Ok(usuarioDto);
        }
        [HttpGet("{id}")]
       public async Task<IActionResult> GetById([FromRoute] long id){
            var usuarioById = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if(usuarioById == null){
                return NotFound("Usuario com ID " + id + " não existe na base de dados.");
            }
            return Ok(usuarioById.ToUsuarioDto());
       } 

       [HttpPost]
       public async Task<IActionResult> Create([FromBody] CreateUsuarioRequestDto request){

            if(request.NomeCompleto.Equals("") || request.Email.Equals("") || request.Senha.Equals("")){
                return BadRequest("Nome, email ou Senha não podem ser vazios.");
            }

            var usuarioModel = request.ToUsuarioFromCreateUsuarioRequestDto();
            usuarioModel = await _usuarioRepository.CreateUsuarioAsync(usuarioModel);
            return CreatedAtAction(nameof(GetById), new {id = usuarioModel.Id}, usuarioModel.ToUsuarioDto());
       }
        
       [HttpPut]
       [Route("{id}")]
       public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateUsuarioRequestDto requestDto){
           
            var usuarioById = await _usuarioRepository.UpdateUsuarioAsync(id, requestDto);
           
            if(usuarioById == null){
                return NotFound("Usuario com ID " + id + " não existe na base de dados.");
            }

            // if(request.NomeCompleto.Equals("") && request.Cpf.Equals("") && request.Cnpj.Equals("") && request.Email.Equals("") && request.Senha.Equals("")) {

            //     return NotFound("Os dados não foram alterados. Pelo menos uma propriedade deve ser alterada.");
            // } mesma immplementacao embaixo

            if (!requestDto.GetType().GetProperties().Any(p => p.GetValue(requestDto) != null && !string.IsNullOrEmpty(p.GetValue(requestDto).ToString())))
            {
                return BadRequest("Os dados não foram alterados. Pelo menos uma propriedade deve ser alterada.");
            }

            return Ok(usuarioById.ToUsuarioDto());
       } 

       [HttpDelete]
       [Route("{id}")]
       public async Task<IActionResult> Delete([FromRoute] long id){

            var usuarioById = await _usuarioRepository.DeleteUsuario(id);
            if(usuarioById == null){
                return NotFound("Usuario com ID " + id + " não existe na base de dados.");
            }
            return NoContent();
       }
    }
}