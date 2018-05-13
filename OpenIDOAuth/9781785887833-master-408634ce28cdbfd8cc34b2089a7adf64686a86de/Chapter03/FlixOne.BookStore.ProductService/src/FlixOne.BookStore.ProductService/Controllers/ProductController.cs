﻿using System.Threading.Tasks;
using FlixOne.BookStore.ProductService.Helpers.Extensions;
using FlixOne.BookStore.ProductService.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.BookStore.ProductService.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult Get()
        {
            return new OkObjectResult(_productRepository.GetAll().ToViewModel());
        }

        [HttpGet]
        [Route("GetProductSync")]
        public IActionResult GetIsStillSynchronous()
        {
            var task = Task.Run(async() => await _productRepository.GetAllAsync());
            return new OkObjectResult(task.Result.ToViewModel());
        }

        [HttpGet]
        [Route("GetProductAsync")]
        public async Task<IActionResult> GetAsync()
        {
            var task = Task.Run(() => _productRepository.GetAllAsync().Result.ToViewModel());
            return new OkObjectResult(await task);
        }

        [HttpGet]
        [Route("GetProductAsync1")]
        public async Task<IActionResult> GetAsyncUsingSync()
        {
            return new OkObjectResult(await Task.Run(() => _productRepository.GetAll().ToViewModel()));
        }
    }
}