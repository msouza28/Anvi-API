using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Data;
using Anvi_API.Dtos.imagem;
using Anvi_API.Dtos.publicacao;
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

        public async Task<Publicacao> CreatePublicacaoAsync(CreatePublicacaoRequestDto requestDto)
        {
             var publicacaoModel = new Publicacao{
                UsuarioId = requestDto.UsuarioId,
                MunicipioId = requestDto.MunicipioId,
                Titulo = requestDto.Titulo,
                Comentario = requestDto.Comentario,
                Status = 1,
            };
            //cria a publicação para que seja utilizado o ID da publicaçao
                _context.Publicacoes.Add(publicacaoModel);
                await _context.SaveChangesAsync();

            foreach(CreateImagemRequestDto iDto in requestDto.ImagensDto){
                var i = new Imagem{
                    PublicacaoId = publicacaoModel.Id,
                    CaminhoImg = iDto.CaminhoImg
                };
                // salva a imagem depois de ter criado a publicação
                _context.Imagens.Add(i);
            }

             await _context.SaveChangesAsync();

                return publicacaoModel;
        }

        public async Task<List<Publicacao>> GetAllPublicacao()
        {
            return await _context.Publicacoes.Include(i => i.Imagens).ToListAsync();
        }

        public async Task<Publicacao?> GetByIdAsync(long id)
        {
            return await _context.Publicacoes.Include(i => i.Imagens).FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<Publicacao?> DeleteById(long id)
        {
           var publicacaoById = await _context.Publicacoes.Include(i => i.Imagens).FirstOrDefaultAsync(i => i.Id == id);
           if(publicacaoById == null){
            return null;
           }
            _context.Publicacoes.Remove(publicacaoById);
            await _context.SaveChangesAsync();
            return publicacaoById;
        }
    }
}