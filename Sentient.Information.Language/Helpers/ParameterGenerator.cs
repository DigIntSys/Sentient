using Sentient.Resources.Abstracts.External;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Headers;

namespace Sentient.Information.Language.Helpers
{
    internal static class ParameterGenerator
    {

        public static Parameters GenerateParameters(string queryWord, string route)
        {
            var headers = new Dictionary<string, string>();

            string oxfordAppId = ConfigurationManager.AppSettings["OxfordApi.App_Id"];
            headers.Add("app_id", oxfordAppId);

            string oxfordApiKey = ConfigurationManager.AppSettings["OxfordApi.App_Key"];
            headers.Add("app_key", oxfordApiKey);

            headers.Add("Accept", new MediaTypeWithQualityHeaderValue("application/json").ToString());

            string oxfordAPIHostname = ConfigurationManager.AppSettings["OxfordApi.Uri"];

            return new Parameters()
            {
                HeaderData = headers,
                Route = route,
                Url = oxfordAPIHostname + route,
                QueryWord = queryWord
            };
        }
    }
}
