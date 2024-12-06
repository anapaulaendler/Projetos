using ArcheologicalSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArcheologicalSite.Controllers
{
    [ApiController]
    [Route("import")]
    public class ImportCsvController : ControllerBase
    {
        private readonly ILogger<ImportCsvController> _logger;
        private readonly ICsvImportService _csvImportService;

        public ImportCsvController(ILogger<ImportCsvController> logger, ICsvImportService csvImportService)
        {
            _logger = logger;
            _csvImportService = csvImportService;
        }

        [HttpPost]
        public async Task<IActionResult> ImportCsv(IFormFile peopleCsv, IFormFile fossilsCsv, IFormFile artefactsCsv)
        {
            if (peopleCsv is null || peopleCsv.Length == 0)
                return BadRequest("Arquivo CSV inválido: Pessoas.");
            if (fossilsCsv is null || fossilsCsv.Length == 0)
                return BadRequest("Arquivo CSV inválido: Fósseis.");
            if (artefactsCsv is null || artefactsCsv.Length == 0)
                return BadRequest("Arquivo CSV inválido: Fósseis.");

            using var peopleStream = peopleCsv.OpenReadStream();
            using var fossilsStream = fossilsCsv.OpenReadStream();
            using var artefactsStream = artefactsCsv.OpenReadStream();

            await _csvImportService.ProcessPeopleAsync(peopleStream);
            await _csvImportService.ProcessArtefactsAsync(artefactsStream);
            await _csvImportService.ProcessFossilsAsync(fossilsStream);

            return Ok();
        }
    }
}