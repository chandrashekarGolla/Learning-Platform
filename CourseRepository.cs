/*using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace Repositories
{
    public class CourseRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public CourseRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var query = _container.GetItemQueryIterator<Course>();
            var results = new List<Course>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Course> GetCourseById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Course>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task CreateCourse(Course course)
        {
            await _container.CreateItemAsync(course, new PartitionKey(course.Id));
        }

        public async Task UpdateCourse(Course course)
        {
            await _container.ReplaceItemAsync(course, course.Id, new PartitionKey(course.Id));
        }

        public async Task DeleteCourse(string id)
        {
            await _container.DeleteItemAsync<Course>(id, new PartitionKey(id));
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
    public class CourseRepository : ICourseRepository
    {
        private readonly Container _container;

        public CourseRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var query = _container.GetItemQueryIterator<Course>();
            var results = new List<Course>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Course> GetCourseById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Course>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task CreateCourse(Course course)
        {
            await _container.CreateItemAsync(course, new PartitionKey(course.Id));
        }

        public async Task UpdateCourse(Course course)
        {
            await _container.ReplaceItemAsync(course, course.Id, new PartitionKey(course.Id));
        }

        public async Task DeleteCourse(string id)
        {
            await _container.DeleteItemAsync<Course>(id, new PartitionKey(id));
        }
    }
}
