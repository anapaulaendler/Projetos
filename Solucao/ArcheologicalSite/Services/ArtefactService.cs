using ArcheologicalSite.Context;
using ArcheologicalSite.Models;
using ArcheologicalSite.Repositories;

namespace ArcheologicalSite.Services
{

    public class ArtefactService : IArtefactService
    {
        private readonly IArtefactRepository _artefactRepository;
        private readonly IArcheologistRepository _archeologistRepository;
        private readonly IUnitOfWork _uow;

        public ArtefactService(IArtefactRepository artefactRepository, IUnitOfWork uow, IArcheologistRepository archeologistRepository)
        {
            _artefactRepository = artefactRepository;
            _uow = uow;
            _archeologistRepository = archeologistRepository;
        }

        public async Task CreateArtefactAsync(Artefact artefact)
        {
            await _uow.BeginTransactionAsync();
            await _artefactRepository.AddAsync(artefact);
            await _uow.CommitTransactionAsync();
        }

        public async Task DeleteArtefactAsync(Guid id)
        {
            await _uow.BeginTransactionAsync();
            var artefact = await _artefactRepository.GetById(id);
            await _artefactRepository.Delete(artefact);
            await _uow.CommitTransactionAsync();
        }

        public async Task<IEnumerable<Artefact>> GetAllArtefactsAsync()
        {
            return await _artefactRepository.Get();
        }

        public async Task<Artefact> GetArtefactByIdAsync(Guid id)
        {
            var artefact = await _artefactRepository.GetById(id);
            return artefact;
        }

        public async Task<Artefact> UpdateArtefactAsync(Artefact updatedArtefact, Guid id)
        {
            await _uow.BeginTransactionAsync();
            var artefact = await GetArtefactByIdAsync(id);

            artefact.Name = updatedArtefact.Name;
            artefact.Period = updatedArtefact.Period;
            artefact.Origin = updatedArtefact.Origin;

            artefact.Function = updatedArtefact.Function;
            artefact.Dimension = updatedArtefact.Dimension;
            artefact.Material = updatedArtefact.Material;

            if (updatedArtefact.ArcheologistId is not null)
            {
                artefact.Archeologist = await _archeologistRepository.GetById((Guid)updatedArtefact.ArcheologistId);
            }
            
            artefact.ArcheologistId = updatedArtefact.ArcheologistId;

            await _artefactRepository.Update(artefact);
            await _uow.CommitTransactionAsync();
            
            return artefact;
        }
    }
}