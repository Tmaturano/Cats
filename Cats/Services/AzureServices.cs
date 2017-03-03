using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
namespace Cats.Services
{
    public class AzureServices<T>
    {
        
        private readonly IMobileServiceClient _client;

        /// <summary>
        /// This represents a table on the backend
        /// </summary>
        private readonly IMobileServiceTable<T> _table;


        public AzureServices()
        {
            string theCatsAppServiceURL = "http://thecatsapp.azurewebsites.net";
            _client = new MobileServiceClient(theCatsAppServiceURL);
            _table = _client.GetTable<T>();
        }

        /// <summary>
        /// To Allow get the data of a table as an IEnumerable
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetTable()
        {
            return _table.ToEnumerableAsync();
        }
    }
}
