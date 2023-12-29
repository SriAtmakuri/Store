using FashionStore.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FashionStoreController : ControllerBase
    {
        private readonly IFashionStoreService _service;

        public FashionStoreController(IFashionStoreService service)
        {
           _service = service;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetProducts();
            return Ok(products);
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _service.GetCountries();
            return Ok(countries);
        }

        [HttpGet("currency")]
        public async Task<IActionResult> GetCurrency(string currencyCode)
        {
            var countries = await _service.GetCurrency(currencyCode);
            return Ok(countries);
        }
    }
}
