using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    /// <summary>
    /// Provides extensions methods for <see cref="HttpClient"/>.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Executes http request and return response message.
        /// <para>
        ///     This method process the redirect status codes explicitly.
        /// </para>
        /// </summary>
        /// <param name="client">The http client instance.</param>
        /// <param name="url">The desired url.</param>
        /// <param name="headers">The request headers.</param>
        /// <param name="maxRedirectAttempts">Max count of client redirect attempts.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns>The asynchronous task with resulting object - <see cref="HttpResponseMessage"/>.</returns>
        public static Task<HttpResponseMessage> GetAsync(this HttpClient client, string url, IDictionary<string, string>? headers, uint maxRedirectAttempts, CancellationToken cancellationToken)
        {
            return client.GetAsync(new Uri(url), headers, maxRedirectAttempts, cancellationToken);
        }

        /// <summary>
        /// Executes http request and return response message.
        /// <para>
        ///     This method process the redirect status codes explicitly.
        /// </para>
        /// </summary>
        /// <param name="client">The http client instance.</param>
        /// <param name="uri">Request uri.</param>
        /// <param name="headers">The request headers.</param>
        /// <param name="maxRedirectAttempts">Max count of client redirect attempts.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <exception cref="HttpRequestException"></exception>
        /// <returns>The asynchronous task with resulting object - <see cref="HttpResponseMessage"/>.</returns>
        public static async Task<HttpResponseMessage> GetAsync(this HttpClient client, Uri uri, IDictionary<string, string>? headers, uint maxRedirectAttempts, CancellationToken cancellationToken)
        {
            maxRedirectAttempts = Math.Max(1, maxRedirectAttempts);

            uint redirectCounter = 0;
            HttpResponseMessage response;

            do
            {
                var message = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri
                };

                if (headers?.Count > 0)
                {
                    foreach (var kv in headers)
                    {
                        message.Headers.TryAddWithoutValidation(kv.Key, kv.Value);
                    }
                }

                response = await client.SendAsync(message, cancellationToken).ConfigureAwait(false);

                var statusCode = (int)response.StatusCode;
                if (statusCode > 300 && statusCode < 400)
                {
                    redirectCounter++;
                    uri = response.Headers.Location;
                }
                else
                {
                    break;
                }

            } while (redirectCounter < maxRedirectAttempts);

            return response;
        }
    }
}
