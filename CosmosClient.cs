/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Models;
using Microsoft.Azure.Cosmos;

using Microsoft.Extensions.Options;

// CosmosDbClient.cs
public class CosmosDbClient : ICosmosDbClient
{
    private readonly CosmosClient _cosmosClient;
    private readonly CosmosDbSettings _cosmosDbSettings;

    public CosmosDbClient(IOptions<CosmosDbSettings> cosmosDbSettings)
    {
        _cosmosDbSettings = cosmosDbSettings.Value;
        _cosmosClient = new CosmosClient(_cosmosDbSettings.EndpointUri, _cosmosDbSettings.PrimaryKey);
    }

    public async Task<Microsoft.Azure.Cosmos.Container> GetCourseContainer()
    {
        Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosDbSettings.DatabaseName);
        return await database.CreateContainerIfNotExistsAsync(_cosmosDbSettings.CourseContainerName, "/id");
    }

    public async Task<Microsoft.Azure.Cosmos.Container> GetChapterContainer()
    {
        Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosDbSettings.DatabaseName);
        return await database.CreateContainerIfNotExistsAsync(_cosmosDbSettings.ChapterContainerName, "/id");
    }
}


 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

public class CosmosDbClient : ICosmosDbClient
{
    private readonly CosmosClient _cosmosClient;
    private readonly CosmosDbSettings _cosmosDbSettings;

    public CosmosDbClient(IOptions<CosmosDbSettings> cosmosDbSettings)
    {
        _cosmosDbSettings = cosmosDbSettings.Value;
        _cosmosClient = new CosmosClient(_cosmosDbSettings.EndpointUri, _cosmosDbSettings.PrimaryKey);
    }

    public async Task<Microsoft.Azure.Cosmos.Container> GetCourseContainer()
    {
        Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosDbSettings.DatabaseName);
        return await database.CreateContainerIfNotExistsAsync(_cosmosDbSettings.CourseContainerName, "/id");
    }

    public async Task<Microsoft.Azure.Cosmos.Container> GetChapterContainer()
    {
        Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosDbSettings.DatabaseName);
        return await database.CreateContainerIfNotExistsAsync(_cosmosDbSettings.ChapterContainerName, "/id");
    }
}
