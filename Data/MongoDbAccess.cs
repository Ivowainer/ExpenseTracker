using DotEnv.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExpenseTracker.Models;

public class MongoDbAccess
{
    private readonly MongoClient _client;
    private readonly IEnvReader _reader;
    public readonly ExpenseTrackerDatabaseSettings _settings;

    public MongoDbAccess(IOptions<ExpenseTrackerDatabaseSettings> settings, IEnvReader reader)
    {
        _settings = settings.Value;
        _reader = reader;
        _client = new MongoClient(_reader["MONGO_URI"]);
    }

    public IMongoDatabase GetDatabase()
    {
        return _client.GetDatabase(_settings.DatabaseName);
    }
}