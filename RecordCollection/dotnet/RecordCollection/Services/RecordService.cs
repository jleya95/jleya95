using RestSharp;
using RestSharp.Authenticators.OAuth;
using RestSharp.Authenticators;

namespace RecordCollection.Services
{
    public class RecordService : IRecordService
    {
        private readonly string BaseURL = "https://api.discogs.com/";
        private readonly OAuth1Authenticator oAuth1 = OAuth1Authenticator.ForAccessToken(
                consumerKey: "WJBVGFnwtOKaLhYdiXTN",
                consumerSecret: "ETBSIjcNuGcpmNISpnjenMOUHLwssluf",
                token: "jyRvFJfQrGujtIdgsabmiVYFQhRHcVEbaBwrSSYn",
                tokenSecret: "ASAKRAcrauTqFMpPqHfyOvlwtnSuvHssgwzMgPjm",
                OAuthSignatureMethod.PlainText);

        private static RestClient client = null;

        public RecordService()
        {
            if (client == null)
            {
                client = new RestClient();
            }
        }

        
    }
}
