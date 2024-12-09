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

        // [HttpPost]
        // public async Task<IActionResult> ImportCsv(IFormFile peopleCsv, IFormFile fossilsCsv, IFormFile artefactsCsv)
        // {
        //     if (peopleCsv is null || peopleCsv.Length == 0)
        //         return BadRequest("Arquivo CSV inválido: Pessoas.");
        //     if (fossilsCsv is null || fossilsCsv.Length == 0)
        //         return BadRequest("Arquivo CSV inválido: Fósseis.");
        //     if (artefactsCsv is null || artefactsCsv.Length == 0)
        //         return BadRequest("Arquivo CSV inválido: Fósseis.");

        //     using var peopleStream = peopleCsv.OpenReadStream();
        //     using var fossilsStream = fossilsCsv.OpenReadStream();
        //     using var artefactsStream = artefactsCsv.OpenReadStream();

        //     await _csvImportService.ProcessPeopleAsync(peopleStream);
        //     await _csvImportService.ProcessArtefactsAsync(artefactsStream);
        //     await _csvImportService.ProcessFossilsAsync(fossilsStream);

        //     return Ok();
        // }

        [HttpPost("artefact")]
        public async Task<IActionResult> ImportCsv(IFormFile artefactsCsv)
        {
            if (artefactsCsv is null || artefactsCsv.Length == 0)
                return BadRequest("Arquivo CSV inválido: Fósseis.");

            var artefactsPath = Path.GetTempFileName();

            using (var artefactsStream = new FileStream(artefactsPath, FileMode.Create))
            {
                await artefactsCsv.CopyToAsync(artefactsStream);
            }

            await _csvImportService.ProcessArtefactsAsync(artefactsPath);

            return Ok();
        }

        [HttpPost("fossil")]
        public async Task<IActionResult> ImportFossil(IFormFile fossilsCsv)
        {
            if (fossilsCsv is null || fossilsCsv.Length == 0)
                return BadRequest("Arquivo CSV inválido: Fósseis.");

            var fossilsPath = Path.GetTempFileName();

            using (var fossilsStream = new FileStream(fossilsPath, FileMode.Create))
            {
                await fossilsCsv.CopyToAsync(fossilsStream);
            }

            await _csvImportService.ProcessFossilsAsync(fossilsPath);

            return Ok();
        }

        [HttpPost("people")]
        public async Task<IActionResult> ImportPeople(IFormFile peopleCsv)
        {
            if (peopleCsv is null || peopleCsv.Length == 0)
                return BadRequest("Arquivo CSV inválido: Pessoas.");

            using var peopleStream = peopleCsv.OpenReadStream();

            await _csvImportService.ProcessPeopleAsync(peopleStream);

            return Ok();
        }
    }
}