using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ICosmosDbClient.cs
namespace Repositories
{
    public interface ICosmosDbClient
    {
        Task<Microsoft.Azure.Cosmos.Container> GetCourseContainer();
        Task<Microsoft.Azure.Cosmos.Container> GetChapterContainer();
    }


}

