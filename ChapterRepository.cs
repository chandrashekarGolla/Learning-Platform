/*using Microsoft.Azure.Cosmos;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
*//*using Learning_Platform.Models;*//*
using Models;

namespace Repositories
{
    public class ChapterRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public ChapterRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Chapter>> GetAllChapters()
        {
            var query = _container.GetItemQueryIterator<Chapter>();
            var results = new List<Chapter>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Chapter> GetChapterById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Chapter>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task CreateChapter(Chapter chapter)
        {
            await _container.CreateItemAsync(chapter, new PartitionKey(chapter.Id));
        }

        public async Task UpdateChapter(Chapter chapter)
        {
            await _container.ReplaceItemAsync(chapter, chapter.Id, new PartitionKey(chapter.Id));
        }

        public async Task DeleteChapter(string id)
        {
            await _container.DeleteItemAsync<Chapter>(id, new PartitionKey(id));
        }
    }
}
*/

using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly Container _container;

        public ChapterRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Chapter>> GetAllChapters()
        {
            var query = _container.GetItemQueryIterator<Chapter>();
            var results = new List<Chapter>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Chapter> GetChapterById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Chapter>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task CreateChapter(Chapter chapter)
        {
            await _container.CreateItemAsync(chapter, new PartitionKey(chapter.Id));
        }

        public async Task UpdateChapter(Chapter chapter)
        {
            await _container.ReplaceItemAsync(chapter, chapter.Id, new PartitionKey(chapter.Id));
        }

        public async Task DeleteChapter(string id)
        {
            await _container.DeleteItemAsync<Chapter>(id, new PartitionKey(id));
        }
    }
}
