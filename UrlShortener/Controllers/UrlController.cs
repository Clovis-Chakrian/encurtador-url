using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortener.Repository;
using System.Web;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlRepository _repository;

        public UrlController(IUrlRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var url = await _repository.SearchUrl(id);
            return Redirect($"{url.url}");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var urls = await _repository.SearchUrls();
            return urls.Any() ? Ok(urls) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Url url)
        {
            _repository.AddUrl(url);
            await _repository.SaveChangesAsync();
            url.shortenerUrl = $"http://localhost:5159/api/Url/{url.id}";
            _repository.UpdateUrl(url);
            return await _repository.SaveChangesAsync() ? Ok($"Url encurtada com sucesso! Link: http://localhost:5159/api/Url/{url.id}") : BadRequest("Erro ao encurtar url.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hasUrl = await _repository.SearchUrl(id);
            if (hasUrl == null) return NotFound($"Url de id {id} não foi encontrada.");

            _repository.DeleteUrl(hasUrl);
            return await _repository.SaveChangesAsync() ? Ok("Url deletada com sucesso.") : BadRequest("Houve um erro ao deletar a url.");
        }
    }
}