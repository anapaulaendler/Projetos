using ArcheologicalSite.Context;
using ArcheologicalSite.Models;
using ArcheologicalSite.Repositories;

namespace ArcheologicalSite.Services
{

    public class PaleontologistService : IPaleontologistService
    {
        private readonly IPaleontologistRepository _paleontologistRepository;
        private readonly IUnitOfWork _uow;

        public PaleontologistService(IPaleontologistRepository paleontologistRepository, IUnitOfWork uow)
        {
            _paleontologistRepository = paleontologistRepository;
            _uow = uow;
        }

        public async Task CreatePaleontologistAsync(Paleontologist paleontologist)
        {
            await _uow.BeginTransactionAsync();
            await _paleontologistRepository.AddAsync(paleontologist);
            await _uow.CommitTransactionAsync();
        }

        public async Task DeletePaleontologistAsync(Guid id)
        {
            await _uow.BeginTransactionAsync();
            var paleontologist = await _paleontologistRepository.GetById(id);
            await _paleontologistRepository.Delete(paleontologist);
            await _uow.CommitTransactionAsync();
        }

        public async Task<IEnumerable<Paleontologist>> GetAllPaleontologistsAsync()
        {
            return await _paleontologistRepository.Get();
        }

        public async Task<Paleontologist> GetPaleontologistByIdAsync(Guid id)
        {
            var paleontologist = await _paleontologistRepository.GetById(id);
            return paleontologist;
        }

        public async Task<Paleontologist> UpdatePaleontologistAsync(Paleontologist updatedPaleontologist, Guid id)
        {
            await _uow.BeginTransactionAsync();
            var paleontologist = await GetPaleontologistByIdAsync(id);

            paleontologist.Name = updatedPaleontologist.Name;

            await _paleontologistRepository.Update(paleontologist);
            await _uow.CommitTransactionAsync();
            
            return paleontologist;
        }
    }
}