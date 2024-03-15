using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anvi_API.Models;

namespace Anvi_API.Repository.Interface
{
    public interface IPublicacaoRepository
    {
        
        public Task<List<Publicacao>> GetAllPublicacao();
    }
}