﻿using AutoMapper;
using MongoDB.Driver;
using SportStore.Services.Catalog.Dtos;
using SportStore.Services.Catalog.Models;
using SportStore.Services.Catalog.Settings;
using SportStore.Shared.Dtos;
using SportStore.Shared.Messages;
using Mass = MassTransit;

namespace SportStore.Services.Catalog.Services;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    private readonly Mass.IPublishEndpoint _publishEndpoint;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings, Mass.IPublishEndpoint publishEndpoint)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductColletionName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Response<List<ProductDto>>> GetAllAsync()
    {
        var products = await _productCollection.Find(product => true).ToListAsync();

        if (products.Any())
        {
            foreach (var product in products)
            {
                product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId).FirstAsync();
            }
        }
        else
        {
            products = new List<Product>();
        }

        return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
    }

    public async Task<Response<ProductDto>> GetByIdAsync(string id)
    {
        var product = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();

        if (product == null)
        {
            return Response<ProductDto>.Fail("Product not found", 404);
        }
        product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId).FirstAsync();

        return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
    }

    public async Task<Response<List<ProductDto>>> GetAllByUserIdAsync(string userId)
    {
        var products = await _productCollection.Find<Product>(x => x.UserId == userId).ToListAsync();

        if (products.Any())
        {
            foreach (var product in products)
            {
                product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId).FirstAsync();
            }
        }
        else
        {
            products = new List<Product>();
        }

        return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
    }

    public async Task<Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
    {
        var newProduct = _mapper.Map<Product>(productCreateDto);

        newProduct.CreatedDate = DateTime.Now;
        await _productCollection.InsertOneAsync(newProduct);

        return Response<ProductDto>.Success(_mapper.Map<ProductDto>(newProduct), 200);

    }

    public async Task<Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        var updateProduct = _mapper.Map<Product>(productUpdateDto);
        var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == productUpdateDto.Id, updateProduct);

        if (result == null)
        {
            return Response<NoContent>.Fail("Product not found", 404);
        }

        await _publishEndpoint.Publish<ProductNameChangedEvent>(new ProductNameChangedEvent
        {
            ProductId = updateProduct.Id,
            UpdatedName = productUpdateDto.Name
        });


        return Response<NoContent>.Success(204);
    }

    public async Task<Response<NoContent>> DeleteAsync(string id)
    {
        var result = await _productCollection.DeleteOneAsync(x => x.Id == id);

        if (result.DeletedCount > 0)
        {
            return Response<NoContent>.Success(204);
        }
        return Response<NoContent>.Fail("Product not found", 404);
    }
}

