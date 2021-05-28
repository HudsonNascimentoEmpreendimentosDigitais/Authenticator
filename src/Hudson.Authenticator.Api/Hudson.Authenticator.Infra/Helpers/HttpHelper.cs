using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RND.IB.Autenticacao.Infra.HTTP
{
    public class HttpHelper : HttpClient
    {

        public async Task<T> GetAsync<T>(string url, object content = null, string bearer = null, string token = null) where T : new()
        {
            try
            {
                using var client = new HttpClient();

                var jsonContent = JsonConvert.SerializeObject(content);
                var queryParams = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonContent);
                var parameters = new Dictionary<string, string>();
                if (queryParams != null)
                {
                    foreach (var item in queryParams)
                    {
                        parameters.Add(item.Key, item.Value.ToString());
                    }
                }

                var requestUri = queryParams == null ? new Uri(url) : new Uri(QueryHelpers.AddQueryString(url, parameters));
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = requestUri
                };

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Add("Token", token);
                }

                if (!string.IsNullOrEmpty(bearer))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearer);
                }

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(json) && response.Content.Headers.ContentType.MediaType.Equals("application/json"))
                    {
                        return JsonConvert.DeserializeObject<T>(json);
                    }
                    else
                    {
                        var objJson = JsonConvert.SerializeObject(response);
                        return JsonConvert.DeserializeObject<T>(objJson);
                    }
                }

                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }
        public async Task<T> PostAsync<T>(string url, object content = null, string token = null, string header = null, string bearer = null) where T : new()
        {
            try
            {
                using var client = new HttpClient();

                var ObjectContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                if (!string.IsNullOrEmpty(header))
                {
                    client.DefaultRequestHeaders.Add("Token", header);
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                }

                if (!string.IsNullOrEmpty(bearer))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearer);
                }

                var response = await client.PostAsync(new Uri(url), ObjectContent);

                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }

                if (response.IsSuccessStatusCode)
                {
                    return new T();
                }

                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }
        public async Task<T> PutAsync<T>(string url, object content = null, string token = null, string header = null, string bearer = null) where T : new()
        {
            try
            {
                using var client = new HttpClient();

                var ObjectContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                if (!string.IsNullOrEmpty(header))
                {
                    client.DefaultRequestHeaders.Add("Token", header);
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                }

                if (!string.IsNullOrEmpty(bearer))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearer);
                }

                var response = await client.PutAsync(new Uri(url), ObjectContent);

                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }

                if (response.IsSuccessStatusCode)
                {
                    return new T();
                }

                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }
        public async Task<T> DeleteAsync<T>(string url, object content = null, string bearer = null, string token = null) where T : new()
        {
            try
            {
                using var client = new HttpClient();

                var jsonContent = JsonConvert.SerializeObject(content);
                var queryParams = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonContent);
                var parameters = new Dictionary<string, string>();
                if (queryParams != null)
                {
                    foreach (var item in queryParams)
                    {
                        parameters.Add(item.Key, item.Value.ToString());
                    }
                }

                var requestUri = queryParams == null ? new Uri(url) : new Uri(QueryHelpers.AddQueryString(url, parameters));

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = requestUri
                };

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Add("Token", token);
                }

                if (!string.IsNullOrEmpty(bearer))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearer);
                }

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(json) && response.Content.Headers.ContentType.MediaType.Equals("application/json"))
                    {
                        return JsonConvert.DeserializeObject<T>(json);
                    }
                    else
                    {
                        var objJson = JsonConvert.SerializeObject(response);
                        return JsonConvert.DeserializeObject<T>(objJson);
                    }
                }

                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}