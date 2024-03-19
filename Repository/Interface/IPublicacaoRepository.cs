using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Dtos.publicacao;
using Anvi_API.Models;

namespace Anvi_API.Repository.Interface
{
    public interface IPublicacaoRepository
    {
        public Task<Publicacao> CreatePublicacaoAsync(CreatePublicacaoRequestDto dto);
        public Task<List<Publicacao>> GetAllPublicacao();
        public  Task<Publicacao?> GetByIdAsync(long id);

        public Task<Publicacao?> DeleteById(long id);
    }
}