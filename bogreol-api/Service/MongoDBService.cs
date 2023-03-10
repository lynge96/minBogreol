using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using shared.Model;

namespace bogreol_api.Service;

public class MongoDBService {

    private readonly IMongoCollection<Book> _bookCollection;
    private readonly Random _random;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _bookCollection = database.GetCollection<Book>(mongoDBSettings.Value.CollectionName);
        _random = new Random();
    }

    public async Task CreateBookAsync(Book book)
    {
        await _bookCollection.InsertOneAsync(book);

        return;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _bookCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Book> GetRandomBookAsync()
    {
        var count = _bookCollection.AsQueryable().Count();
        var randomIndex = _random.Next(count);
        var query = from b in _bookCollection.AsQueryable() select b;

        return query.Skip(randomIndex).First();
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("Id", id);
        await _bookCollection.DeleteOneAsync(filter);
    }

 
}