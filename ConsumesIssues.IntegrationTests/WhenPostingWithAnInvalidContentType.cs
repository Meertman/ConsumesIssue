using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace ConsumesIssues.IntegrationTests
{
    public sealed class WhenPostingWithAnInvalidContentType : IDisposable
    {
        private readonly HttpClient _client;
        private readonly HttpContent _content;
        private readonly WebApplicationFactory _webApplicationFactory;

        public WhenPostingWithAnInvalidContentType()
        {
            _webApplicationFactory = new WebApplicationFactory();

            _client = _webApplicationFactory.CreateClient();

            _content = new StringContent("Testing a post with an invalid content type.");
            _content.Headers.ContentType = new MediaTypeHeaderValue("x-invalid-plain/text");
        }

        public void Dispose()
        {
            _client?.Dispose();
            _content?.Dispose();
            _webApplicationFactory?.Dispose();
        }

        [Fact]
        public async Task ThenNoExceptionIsThrown()
        {
            var exception = await Record.ExceptionAsync(WhenPosting);

            Assert.Null(exception);
        }

        [Fact]
        public async Task ThenTheStatusCodeOfTheResponseIsUnsupportedMediaType()
        {
            var response = await WhenPosting();

            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        private Task<HttpResponseMessage> WhenPosting() => _client.PostAsync("/Test", _content);
    }
}