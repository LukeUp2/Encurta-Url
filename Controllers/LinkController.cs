using Encurtador_Url.Api.Data;
using Encurtador_Url.Api.Dtos;
using Encurtador_Url.Api.Models;
using Encurtador_Url.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Encurtador_Url.Api.Controllers
{
    [Route("/api/links")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly LinkServices linkServices;

        public LinkController(AppDbContext context)
        {
            _context = context;
            linkServices = new LinkServices();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var links = _context.Links.ToList();
            return Ok(links);
        }

        [HttpPost]
        public IActionResult Encurtar([FromBody] LinkRequestDto request)
        {
            string urlShort = $"http://localhost:5062/api/links/r/{linkServices.GerarUrlAleatoria()}";

            Link link = new()
            {
                UrlOriginal = request.UrlOriginal,
                UrlShort = urlShort
            };

            _context.Links.Add(link);
            _context.SaveChanges();

            LinkResponseDto response = new()
            {
                UrlShort = urlShort,
            };

            return Ok(response);
        }

        [HttpGet("r/{urlShort}")]
        public IActionResult RedirectRequest([FromRoute] string urlShort)
        {
            var link = linkServices.ObterUrlOriginal(urlShort, _context);
            Console.WriteLine(link?.UrlOriginal);
            if (link == null)
            {
                return NotFound("Não encontramos o link");
            }


            return Redirect(link.UrlOriginal);
        }
    }
}