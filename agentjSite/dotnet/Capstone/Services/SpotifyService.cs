using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using RestSharp.Authenticators.OAuth2;

namespace agentjSite.Services
{
    public class SpotifyService : ISpotifyService
    {
        private static RestClient client = new RestClient();
        private RestClientOptions options = new RestClientOptions(baseUrl: "https://api.spotify.com")
        {
/*            Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator()
*/        };
        
    }
}
