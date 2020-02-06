using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinTest.ApiModels.Models;
using XamarinTest.ApiModels.Models.Account;
using XamarinTest.Helpers;
using XamarinTest.Services.Interfaces;
using XamarinTest.Services.Models;

namespace XamarinTest.Services {
    public class ApiService : IApiService {
        public async Task<ApiResponse> DoRequestAsync(string method, string url, object parameters) {
            try {
                IDictionary<string, string> dictionaryParameters = ConvertationHelper.ParametersToDictionary(parameters);
                string data = string.Join("&", dictionaryParameters
                    .Select(pair => string.Concat(UrlHelper.UrlEncode(pair.Key), "=", UrlHelper.UrlEncode(pair.Value))));

                var request = (HttpWebRequest)HttpWebRequest.Create(url + "?" + data);
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = 0;
                request.KeepAlive = true;
                request.Method = method;
                request.Headers.Set("X-API-KEY", "343b1ae9-fb57-45fd-90f0-g1e097f9d621");

                string token = ApplicationPropertiesHelper.GetToken();

                request.Headers.Set("Authorization", "Bearer " + token);
                var response = (HttpWebResponse)(request.GetResponseAsync().Result);

                using (var stream = response.GetResponseStream()) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        await reader.ReadToEndAsync();
                        return ApiResponse.Ok();
                    }
                }
            }
            catch (Exception ex) {
                return ApiResponse.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse> DoPostFileAsync(string url, byte[] image, object parameters) {
            try {
                HttpClient client = new HttpClient();
                IDictionary<string, string> dictionaryParameters = ConvertationHelper.ParametersToDictionary(parameters);
                string data = string.Join("&", dictionaryParameters.Select(pair => string.Concat(UrlHelper.UrlEncode(pair.Key), "=", UrlHelper.UrlEncode(pair.Value))));

                ByteArrayContent byteContent = new ByteArrayContent(image);
                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(byteContent, "image", "filename.ext");

                string token = ApplicationPropertiesHelper.GetToken();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.PostAsync(url + "?" + data, content);
                return ApiResponse.Ok();
            } catch (Exception ex) {
                return ApiResponse.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse> DoLoginAsync(string username, string password) {
            try {
                HttpClient client = new HttpClient();
                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("grant_type", "password"), new KeyValuePair<string, string>("client_id", "self"), new KeyValuePair<string, string>("username", username), new KeyValuePair<string, string>("password", password)
                });

                HttpResponseMessage response = await client.PostAsync(UrlHelper.baseUrl + UrlHelper.Token, content);
                var responseString = await response.Content.ReadAsStringAsync();
                var tokenResult = JsonConvert.DeserializeObject<TokenResult>(responseString);

                if (tokenResult.AccessToken != null) {
                    return ApiResponse.Ok(tokenResult.AccessToken);
                } else {
                    return ApiResponse.Fail(response.ToString());
                }
            } catch (Exception ex) {
                return ApiResponse.Fail(ex.Message);
            }
        }

        public async Task<IEnumerable<ImageApiModel>> DoGetFilesAsync() {
            try {
                var request = (HttpWebRequest) HttpWebRequest.Create(UrlHelper.baseUrl + UrlHelper.ImageList);
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = 0;
                request.KeepAlive = true;
                request.Method = "GET";

                string token = ApplicationPropertiesHelper.GetToken();
                request.Headers.Set("X-API-KEY", "343b1ae9-fb57-45fd-90f0-g1e097f9d621");
                request.Headers.Set("Authorization", "Bearer " + token);

                var response = (HttpWebResponse) (request.GetResponseAsync().Result);

                string result = "";
                using (var stream = response.GetResponseStream()) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        result = await reader.ReadToEndAsync();
                    }
                }
                IEnumerable<ImageApiModel> images = JsonConvert.DeserializeObject<IEnumerable<ImageApiModel>>(result);
                return images;
            } catch (Exception ex) {
                return null;
            }
        }
    }
}
