using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Data;
using Anvi_API.Dtos.usuario;
using Anvi_API.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anvi_API.Controller
{
    [ApiController]
    [Route("v1/api/usuario")]
    public class UsuarioController:ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public UsuarioController(AppDbContext dbContext){
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var usuarios =  await _dbContext.Usuarios.ToListAsync();
            var usuarioDto = usuarios.Select(u => u.ToUsuarioDto());
            return Ok(usuarioDto);
        }
        [HttpGet("{id}")]
       public async Task<IActionResult> GetById([FromRoute] long id){
            var usuarioById = await _dbContext.Usuarios.FindAsync(id);
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
            await _dbContext.AddAsync(usuarioModel);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = usuarioModel.Id}, usuarioModel.ToUsuarioDto());
       }
        
       [HttpPut]
       [Route("{id}")]
       public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateUsuarioRequestDto request){
           
            var usuarioById = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
           
            if(usuarioById == null){
                return NotFound("Usuario com ID " + id + " não existe na base de dados.");
            }

            // if(request.NomeCompleto.Equals("") && request.Cpf.Equals("") && request.Cnpj.Equals("") && request.Email.Equals("") && request.Senha.Equals("")) {

            //     return NotFound("Os dados não foram alterados. Pelo menos uma propriedade deve ser alterada.");
            // } mesma immplementacao embaixo

            if (!request.GetType().GetProperties().Any(p => p.GetValue(request) != null && !string.IsNullOrEmpty(p.GetValue(request).ToString())))
            {
                return BadRequest("Os dados não foram alterados. Pelo menos uma propriedade deve ser alterada.");
            }


            usuarioById.NomeCompleto = request.NomeCompleto == "" ? usuarioById.NomeCompleto: request.NomeCompleto;
            if(usuarioById.Cpf.Equals("")){
                usuarioById.Cnpj = request.Cnpj == "" ? usuarioById.Cnpj : request.Cnpj;
            } else {
                usuarioById.Cpf = request.Cpf == "" ? usuarioById.Cpf : request.Cpf;
            }
            usuarioById.Email = request.Email == "" ? usuarioById.Email : request.Email;
            usuarioById.Senha = request.Senha == "" ? usuarioById.Senha : request.Senha;
            usuarioById.DataCadastro = usuarioById.DataCadastro;

           await _dbContext.SaveChangesAsync();

            return Ok(usuarioById.ToUsuarioDto());
       } 

       [HttpDelete]
       [Route("{id}")]
       public async Task<IActionResult> Delete([FromRoute] long id){

            var usuarioById = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if(usuarioById == null){
                return NotFound("Usuario com ID " + id + " não existe na base de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioById);
           await _dbContext.SaveChangesAsync();

            return NoContent();
       }
    }
}