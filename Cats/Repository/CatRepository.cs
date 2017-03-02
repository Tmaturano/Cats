using Cats.Models;
using Cats.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cats.Repository
{
    public class CatRepository
    {
        public async Task<List<Cat>> GetCats()
        {
            //List<Cat> cats;

            //var URLApi = "http://demos.ticapacitacion.com/cats";

            //using (var client = new HttpClient())
            //{
            //    var json = await client.GetStringAsync(URLApi);
            //    cats = JsonConvert.DeserializeObject<List<Cat>>(json);
            //}

            //return cats;

            var service = new AzureServices<Cat>();
            var cats = await service.GetTable();

            return cats.ToList();
        }
    }
}
