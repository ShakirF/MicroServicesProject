﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportStore.Services.Catalog.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }

    public string? UserId { get; set; }

    public string? Picture { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedDate { get; set; }
    public Feature? Feature { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; } = null!;

    [BsonIgnore]
    public Category Category { get; set; } = null!;
}

