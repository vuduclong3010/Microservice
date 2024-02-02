
using ProjectServiceB.Entity;
using System;

namespace ProjectServiceB.Service
{
    public class InsertOrUpdateService : IInsertOrUpdateService
    {
        private readonly DatabaseContext _context;

        public InsertOrUpdateService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertOrUpdateDatabase(string url)
        {
            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri(url);

            // Thực hiện Post
            var response = await httpClient.SendAsync(httpRequestMessage);

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);

            return true;
        }
    }
}
