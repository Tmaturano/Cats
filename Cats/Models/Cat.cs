using Microsoft.WindowsAzure.MobileServices;

namespace Cats.Models
{
    [DataTable("Cats")]
    public class Cat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string WebSite { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// This property allows to take the control of the concurrency of each data of the table
        /// </summary>
        [Version]
        public string AzureVersion { get; set; }
    }
}
