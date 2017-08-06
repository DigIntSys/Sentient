using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Sentient.Resources.Abstracts.External
{
    public class Parameters
    {
        public string Route { get; set; }
        public string Url { get; set; }
        public string Fragments { get; set; }
        public Dictionary<string, string> HeaderData { get; set; }
        public Dictionary<string, string> QueryParameters { get; set; }
        public string QueryWord { get; set; }
    }

    public abstract class ACollector
    {
        public virtual async Task<T> GatherData<T>(Parameters output)
        {
            T model = default(T);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (output.HeaderData != null)
                    {
                        foreach (var header in output.HeaderData)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    var uriBuilder = new UriBuilder(output.Url);

                    if (output.QueryParameters != null)
                    {
                        var parameters = HttpUtility.ParseQueryString(string.Empty);

                        foreach (var parameter in output.QueryParameters)
                        {
                            parameters[parameter.Key] = parameter.Value;
                        }
                        uriBuilder.Query = parameters.ToString();
                    }
                    else
                    {
                        uriBuilder.Path += output.QueryWord;
                    }

                    uriBuilder.Fragment = (!string.IsNullOrEmpty(output.Fragments) ? output.Fragments : "");

                    Uri url = uriBuilder.Uri;

                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            using (HttpContent content = response.Content)
                            {
                                // ... Read the content.
                                string result = await content.ReadAsStringAsync();

                                // ... Store the result.
                                if (result != null)
                                {
                                    model = JsonConvert.DeserializeObject<T>(result);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }

    }
}
