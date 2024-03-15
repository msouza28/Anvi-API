using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Data;
using Anvi_API.Mappers;
using Anvi_API.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Anvi_API.Controller
{
    [ApiController]
    [Route("v1/api/publicacao")]
    public class PublicacaoController(IPublicacaoRepository publicacaoRepository) : ControllerBase
    {
        private readonly IPublicacaoRepository _publicacaoRepository = publicacaoRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllPublicaoes(){
            var publicacoes = await _publicacaoRepository.GetAllPublicacao();
           var publicacaoDto = publicacoes.Select(s => s.ToPublicacaoDto());
            return Ok(publicacaoDto);
        }
    }
}