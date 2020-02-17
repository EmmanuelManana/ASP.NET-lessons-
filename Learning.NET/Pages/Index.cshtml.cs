using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.NET.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Learning.NET.models;

//adding the services into page model.
namespace Learning.NET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService _ProductService;
        //create a list of services.
        public  IEnumerable<Product> Products { get; private set; }//empty IEnumerable

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            _ProductService = productService;//add the service.
        }

        public void OnGet()
        {
            Products = _ProductService.GetProducts(); //fill up the empty IEnumerable
        }
    }
}
