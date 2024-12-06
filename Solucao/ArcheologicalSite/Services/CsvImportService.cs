
using ArcheologicalSite.Context;
using ArcheologicalSite.Repositories;

namespace ArcheologicalSite.Services
{
    public class CsvImportService : ICsvImportService
    {
        private readonly IArcheologistRepository _archeologistRepository;
        private readonly IPaleontologistRepository _paleontologistRepository;
        private readonly IArtefactRepository _artefactRepository;
        private readonly IFossilRepository _fossilRepository;

        private readonly IUnitOfWork _uow;

        public CsvImportService(IArcheologistRepository archeologistRepository, IPaleontologistRepository paleontologistRepository, IArtefactRepository artefactRepository, IFossilRepository fossilRepository, IUnitOfWork uow)
        {
            _archeologistRepository = archeologistRepository;
            _paleontologistRepository = paleontologistRepository;
            _artefactRepository = artefactRepository;
            _fossilRepository = fossilRepository;
            _uow = uow;
        }

        public async Task ProcessItemsAsync(Stream fossilsStream, Stream artefactsStream)
        {
            var artefacts = await _artefactRepository.Get();
            var fossils = await _fossilRepository.Get();

            using var textReader = new StreamReader(fossilsStream);
            string line = textReader.ReadLine()!;

            
        }

        public Task ProcessPeopleAsync(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}