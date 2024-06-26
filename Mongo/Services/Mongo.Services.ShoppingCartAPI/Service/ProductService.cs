﻿using Mongo.Services.ShoppingCartAPI.Models.Dto;
using Mongo.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mongo.Services.ShoppingCartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _factory;

        public ProductService(IHttpClientFactory factory)
        {
            this._factory = factory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _factory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if(resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Results));
            }
            return new List<ProductDto>();
        }
    }
}
