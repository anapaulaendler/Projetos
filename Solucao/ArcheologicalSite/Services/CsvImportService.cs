using System.Globalization;
using ArcheologicalSite.Context;
using ArcheologicalSite.Models;
using ArcheologicalSite.Repositories;
using CsvHelper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ArcheologicalSite.Services
{
    public class CsvImportService : ICsvImportService
    {
        private readonly ILogger<CsvImportService> _logger;

        private readonly IArcheologistRepository _archeologistRepository;
        private readonly IPaleontologistRepository _paleontologistRepository;
        private readonly IArtefactRepository _artefactRepository;
        private readonly IFossilRepository _fossilRepository;

        private readonly IUnitOfWork _uow;

        public CsvImportService(IArcheologistRepository archeologistRepository, IPaleontologistRepository paleontologistRepository, IArtefactRepository artefactRepository, IFossilRepository fossilRepository, IUnitOfWork uow, ILogger<CsvImportService> logger)
        {
            _archeologistRepository = archeologistRepository;
            _paleontologistRepository = paleontologistRepository;
            _artefactRepository = artefactRepository;
            _fossilRepository = fossilRepository;
            _uow = uow;
            _logger = logger;
        }

        public async Task ProcessArtefactsAsync(Stream artefactsStream)
        {
            await _uow.BeginTransactionAsync();

            var newArtefacts = new List<Artefact>();

            var artefacts = await _artefactRepository.Get();
            var archeologists = await _archeologistRepository.Get();

            using var textReader = new StreamReader(artefactsStream);
            using var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (await csv.ReadAsync())
            {
                var model = csv.GetRecord<ArtefactCsvModel>();

                var archeologist = archeologists.FirstOrDefault(x => x.Id == model.ArcheologistId);

                var artefact = new Artefact
                {
                    Name = model.Name,
                    Period = model.Period,
                    Origin = model.Origin,
                    Type = model.Type,
                    Function = model.Function,
                    Dimension = model.Dimension,
                    Material = model.Material,

                    ArcheologistId = model.ArcheologistId,
                    Archeologist = archeologist
                };

                newArtefacts.Add(artefact);
            }
            if (newArtefacts.Any())
            {
                await _artefactRepository.AddRangeAsync(newArtefacts);
            }
            await _uow.CommitTransactionAsync();
        }

        public async Task ProcessFossilsAsync(Stream fossilsStream)
        {
            await _uow.BeginTransactionAsync();

            var newFossils = new List<Fossil>();

            var fossils = await _fossilRepository.Get();
            var paleontologists = await _paleontologistRepository.Get();

            using var textReader = new StreamReader(fossilsStream);
            using var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (await csv.ReadAsync())
            {
                var model = csv.GetRecord<FossilCsvModel>();

                var paleontologist = paleontologists.FirstOrDefault(x => x.Id == model.PaleontologistId);

                var fossil = new Fossil
                {
                    Name = model.Name,
                    Period = model.Period,
                    Origin = model.Origin,
                    Type = model.Type,
                    ScientificName = model.ScientificName,
                    Species = model.Species,
                    Condition = model.Condition,

                    PaleontologistId = model.PaleontologistId,
                    Paleontologist = paleontologist
                };

                newFossils.Add(fossil);
            }
            if (newFossils.Any())
            {
                await _fossilRepository.AddRangeAsync(newFossils);
            }
            await _uow.CommitTransactionAsync();
        }

        public async Task ProcessPeopleAsync(Stream stream)
        {
            await _uow.BeginTransactionAsync();

            var newArcheologists = new List<Archeologist>();
            var newPaleontologists = new List<Paleontologist>();

            var artefacts = _artefactRepository.Get();
            var fossils = _fossilRepository.Get();

            using var textReader = new StreamReader(stream);
            using var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (await csv.ReadAsync())
            {
                var model = csv.GetRecord<PersonCsvModel>();

                if (model.Profession.Equals("Paleontologist", StringComparison.OrdinalIgnoreCase))
                {
                    var paleontologist = new Paleontologist
                    {
                        Name = model.Name,
                        Cpf = model.Cpf,
                        BirthDate = model.BirthDate,
                        ProfessionalRegisterId = model.ProfessionalRegisterId,
                        Profession = model.Profession
                    };
                    
                    newPaleontologists.Add(paleontologist);
                } else if (model.Profession.Equals("Archeologist", StringComparison.OrdinalIgnoreCase))
                {
                    var archeologist = new Archeologist
                    {
                        Name = model.Name,
                        Cpf = model.Cpf,
                        BirthDate = model.BirthDate,
                        ProfessionalRegisterId = model.ProfessionalRegisterId,
                        Profession = model.Profession
                    };
                    
                    newArcheologists.Add(archeologist);
                } else
                {
                    _logger.LogError("Profissão desconhecida: {Profession}", model.Profession);
                    continue;
                }
            }
            if (newArcheologists.Any())
            {
                await _archeologistRepository.AddRangeAsync(newArcheologists);
            }

            if (newPaleontologists.Any())
            {
                await _paleontologistRepository.AddRangeAsync(newPaleontologists);
            }
            await _uow.CommitTransactionAsync();
        }
    }
}