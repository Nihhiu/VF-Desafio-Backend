using Microsoft.AspNetCore.Mvc;
using Service.University;

namespace Controller.University;

[Route("university")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly UniversityService _universityService;

    public UniversityController(UniversityService universityService)
    {
        _universityService = universityService;
    }

    // Listar todas as universidades
    [HttpGet("all")]
        public async Task<IActionResult> GetAllUniversities()
        {
            var universities = await _universityService.GetUniversities();

            if (universities == null || !universities.Any())
            {
                return NotFound(new { message = "Nenhuma universidade encontrada."});
            }

            var results = universities
                .Select(u => new { u.Name, u.Web_pages })
                .ToList();

            return Ok(results);
    }

    // Listar universidades por nome, em ordem ou contagem
    [HttpGet("search")]
        public async Task<IActionResult> GetUniversitiesByName(
            [FromQuery] string name,
            [FromQuery] string? order,
            [FromQuery] bool count = false)
        {
            if (string.IsNullOrEmpty(name)){
                return BadRequest(new { message = "Nome não fornecido."});
            }
            
            var universities = await _universityService.GetUniversities();

            if (universities == null || !universities.Any()) {
                return NotFound(new { message = "Nenhuma universidade encontrada."});
            }

            var results = universities
                .Where(u => u.Name.StartsWith(name, StringComparison.CurrentCultureIgnoreCase))
                .Select(u => new { u.Name, u.Web_pages })
                .ToList();

            // Contagem
            if (count) {
                return Ok(new { count = results.Count });
            }

            // Ordenação
            if (!string.IsNullOrEmpty(order)) {
                if (order == "asc") {
                    results = results.OrderBy(u => u.Name).ToList();
                }
                else if (order == "desc") {
                    results = results.OrderByDescending(u => u.Name).ToList();
                }
                else {
                    return BadRequest(new { message = "Ordenação inválida."});
                }
            }

            return Ok(results);
    }
}