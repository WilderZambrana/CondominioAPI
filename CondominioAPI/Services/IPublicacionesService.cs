using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface IPublicacionesService
    {
        public Task<IEnumerable<PublicacionModel>> GetPublicacionesAsync(long personaId);
        public Task<PublicacionModel> GetPublicacionAsync(long personaId, long publicacionId);
        public Task<PublicacionModel> CreatePublicacionAsync(long personaId, PublicacionModel newPublicacion);
        public Task<bool> DeletePublicacionAsync(long personaId, long publicacionId);
        public Task<PublicacionModel> UpdatePublicacionAsync(long personaId, long publicacionId, PublicacionModel updatedPublicacion);
    }
}
