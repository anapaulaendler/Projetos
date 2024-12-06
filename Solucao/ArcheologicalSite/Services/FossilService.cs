using ArcheologicalSite.Context;
using ArcheologicalSite.Models;
using ArcheologicalSite.Repositories;

namespace ArcheologicalSite.Services
{

    public class FossilService : IFossilService
    {
        private readonly IFossilRepository _fossilRepository;
        private readonly IPaleontologistRepository _paleontologistRepository;
        private readonly IUnitOfWork _uow;

        public FossilService(IFossilRepository fossilRepository, IUnitOfWork uow, IPaleontologistRepository paleontologistRepository)
        {
            _fossilRepository = fossilRepository;
            _uow = uow;
            _paleontologistRepository = paleontologistRepository;
        }

        public async Task CreateFossilAsync(Fossil fossil)
        {
            await _uow.BeginTransactionAsync();
            await _fossilRepository.AddAsync(fossil);
            await _uow.CommitTransactionAsync();
        }

        public async Task DeleteFossilAsync(Guid id)
        {
            await _uow.BeginTransactionAsync();
            var fossil = await _fossilRepository.GetById(id);
            await _fossilRepository.Delete(fossil);
            await _uow.CommitTransactionAsync();
        }

        public async Task<IEnumerable<Fossil>> GetAllFossilsAsync()
        {
            return await _fossilRepository.Get();
        }

        public async Task<Fossil> GetFossilByIdAsync(Guid id)
        {
            var fossil = await _fossilRepository.GetById(id);
            return fossil;
        }

        public async Task<Fossil> UpdateFossilAsync(Fossil updatedFossil, Guid id)
        {
            await _uow.BeginTransactionAsync();
            var fossil = await GetFossilByIdAsync(id);

            fossil.Name = updatedFossil.Name;
            fossil.Period = updatedFossil.Period;
            fossil.Origin = updatedFossil.Origin;

            fossil.ScientificName = updatedFossil.ScientificName;
            fossil.Species = updatedFossil.Species;
            fossil.Condition = updatedFossil.Condition;

            if (updatedFossil.PaleontologistId is not null)
            {
                fossil.Paleontologist = await _paleontologistRepository.GetById((Guid)updatedFossil.PaleontologistId);
            }
            
            fossil.PaleontologistId = updatedFossil.PaleontologistId;

            await _fossilRepository.Update(fossil);
            await _uow.CommitTransactionAsync();
            
            return fossil;
        }
    }
}