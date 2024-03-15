using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Data;
using Anvi_API.Models;
using Anvi_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anvi_API.Repository.Impl
{
    public class PublicacaoRepository : IPublicacaoRepository

    {

    private readonly AppDbContext _context;
    
    public PublicacaoRepository(AppDbContext context){
        _context = context;

    }
        public async Task<List<Publicacao>> GetAllPublicacao()
        {
            return await _context.Publicacoes.ToListAsync();
        }
    }
}