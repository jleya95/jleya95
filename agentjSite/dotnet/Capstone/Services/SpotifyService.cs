using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using RestSharp.Authenticators.OAuth2;

namespace agentjSite.Services
{
    public class SpotifyService : ISpotifyService
    {
        const string clientID = "4429774265a942b8b9bbc1157be39562";
        const string clientSecret = "7e791cb9a1d54071ba64e4aad9db0efa";
        private static RestClient client = new RestClient();
        private RestClientOptions options = new RestClientOptions(baseUrl: "https://api.spotify.com")
        {
            Authenticator = new HttpBasicAuthenticator(clientID, clientSecret)
        };

        public SpotifyService() { 
        if (client == null)
            {
                client = new RestClient(options);
            }
        }



        public RestRequest request = new RestRequest().AddHeader("", "").AddParameter("", "");
    }
}
