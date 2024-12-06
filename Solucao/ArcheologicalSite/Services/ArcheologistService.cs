using ArcheologicalSite.Context;
using ArcheologicalSite.Models;
using ArcheologicalSite.Repositories;

namespace ArcheologicalSite.Services
{

    public class ArcheologistService : IArcheologistService
    {
        private readonly IArcheologistRepository _archeologistRepository;
        private readonly IUnitOfWork _uow;

        public ArcheologistService(IArcheologistRepository archeologistRepository, IUnitOfWork uow)
        {
            _archeologistRepository = archeologistRepository;
            _uow = uow;
        }

        public async Task CreateArcheologistAsync(Archeologist archeologist)
        {
            await _uow.BeginTransactionAsync();
            await _archeologistRepository.AddAsync(archeologist);
            await _uow.CommitTransactionAsync();
        }

        public async Task DeleteArcheologistAsync(Guid id)
        {
            await _uow.BeginTransactionAsync();
            var archeologist = await _archeologistRepository.GetById(id);
            await _archeologistRepository.Delete(archeologist);
            await _uow.CommitTransactionAsync();
        }

        public async Task<IEnumerable<Archeologist>> GetAllArcheologistsAsync()
        {
            return await _archeologistRepository.Get();
        }

        public async Task<Archeologist> GetArcheologistByIdAsync(Guid id)
        {
            var archeologist = await _archeologistRepository.GetById(id);
            return archeologist;
        }

        public async Task<Archeologist> UpdateArcheologistAsync(Archeologist updatedArcheologist, Guid id)
        {
            await _uow.BeginTransactionAsync();
            var archeologist = await GetArcheologistByIdAsync(id);

            archeologist.Name = updatedArcheologist.Name;

            await _archeologistRepository.Update(archeologist);
            await _uow.CommitTransactionAsync();
            
            return archeologist;
        }
    }
}