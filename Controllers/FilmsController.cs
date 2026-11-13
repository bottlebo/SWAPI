using Microsoft.AspNetCore.Mvc;
using SWAPI.SERVICES;
namespace SWAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly FilmService _filmService;

        public FilmsController(FilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            return this.FromServiceOperationResult(
               await _filmService.GetAllFilmsAsync()
            );
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmById([FromRoute] int id)
        {
            return this.FromServiceOperationResult(
            await _filmService.GetFilmByIdAsync(id)
            );

        }
        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetFilmByTitle([FromRoute] string title)
        {
            return this.FromServiceOperationResult(
                await _filmService.GetFilmByTitleAsync(title)
            );
        }
        [HttpGet("{filmId}/characters")]
        public async Task<IActionResult> GetCharactersByFilmId([FromRoute] int filmId)
        {
            return this.FromServiceOperationResult(
                await _filmService.GetCharactersByFilmIdAsync(filmId)
            );
        }
        [HttpGet("{filmId}/with-characters")]
        public async Task<IActionResult> GetFilmWithCharacters([FromRoute] int filmId)
        {
            return this.FromServiceOperationResult(
                await _filmService.GetFilmWithCharacters(filmId)
            );
        }
    }
}
