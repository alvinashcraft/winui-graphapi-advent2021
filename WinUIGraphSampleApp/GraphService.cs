using Azure.Identity;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WinUIGraphSampleApp
{
    public class GraphService : IGraphService
    {
        private readonly string[] _scopes = new[] { "User.Read" };
        private const string TenantId = "<your tenant id here>";
        private const string ClientId = "<your client id here>";
        private GraphServiceClient _client;

        public GraphService()
        {
            Initialize();
        }

        private void Initialize()
        {
            var options = new InteractiveBrowserCredentialOptions
            {
                TenantId = TenantId,
                ClientId = ClientId,
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
                RedirectUri = new Uri("http://localhost"),
            };

            var interactiveCredential = new InteractiveBrowserCredential(options);

            _client = new GraphServiceClient(interactiveCredential, _scopes);
        }

        public async Task<User> GetMyDetailsAsync()
        {
            try
            {
                var user = await _client.Me.Request().GetAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user details: {ex}");
                return null;
            }
        }
    }
}
