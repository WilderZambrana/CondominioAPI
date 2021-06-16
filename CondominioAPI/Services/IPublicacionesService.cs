using CondominioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Services
{
    public interface IPublicacionesService
    {
        public Task<IEnumerable<PublicacionModel>> GetPublicacionesAsync();
        public Task<PublicacionModel> GetPublicacionAsync(long publicacionId);
        public Task<PublicacionModel> CreatePublicacionAsync(PublicacionModel newPublicacion);
        public Task<bool> DeletePublicacionAsync(long publicacionId);
        public Task<PublicacionModel> UpdatePublicacionAsync(long publicacionId, PublicacionModel updatedPublicacion);
    }
}
