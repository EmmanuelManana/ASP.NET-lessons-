using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.NET.models;
using Learning.NET.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.NET.Controller
{
    [Route("[controller]")] //request 
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public JsonFileProductService ProductService { get; }
        public Product selectedProduct;
        public string selectedProductId { set; get; }
        public ProductsController(JsonFileProductService  productService)
        {
            this.ProductService = productService;
        }

        [HttpGet] //response.
        public IEnumerable<Product> Get()
        {
            return this.ProductService.GetProducts();
        }

        //[HttpPatch] "fromBody"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductId, [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();

        }

        [Route("First")]
        [HttpGet]
        public ActionResult Get([FromQuery] string productId)
        {
            selectedProductId = productId;
            selectedProduct = ProductService.GetProducts().First(x => x.Id == productId);
            return Ok();
        }

    }
}