using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.Services
{
    public class AzureServices<T>
    {
        IMobileServiceClient Client;

        /// <summary>
        /// This represents a table on the backend
        /// </summary>
        IMobileServiceTable<T> Table;


        public AzureServices()
        {
            string theCatsAppServiceURL = "http://thecatsapp.azurewebsites.net";
            Client = new MobileServiceClient(theCatsAppServiceURL);
            Table = Client.GetTable<T>();
        }

        /// <summary>
        /// To Allow get the data of a table as an IEnumerable
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }

    }
}
