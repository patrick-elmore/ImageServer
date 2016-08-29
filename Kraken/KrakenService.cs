using Interfaces;
using SeaMist;
using SeaMist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraken
{
    public class KrakenService : IImageService
    {
        public string GetLosslessImage(string url)
        {
            KrakenClient client = getKrakenClient();
            OptimizeWaitRequest request = createStandardKrakenRequest(url);

            var result = client.OptimizeWait(request).Result;
            OptimizeWaitResult krakenImage = result.Body;

            return krakenImage.KrakedUrl;
        }

        public string GetLossyImage(string url)
        {
            KrakenClient client = getKrakenClient();
            OptimizeWaitRequest request = createStandardKrakenRequest(url);
            request.Lossy = true;

            var result = client.OptimizeWait(request).Result;
            OptimizeWaitResult krakenImage = result.Body;

            return krakenImage.KrakedUrl;
        }

        private OptimizeWaitRequest createStandardKrakenRequest(string url)
        {
            Uri imageUrl = new Uri(url);

            OptimizeWaitRequest request = new OptimizeWaitRequest(imageUrl);

            return request;
        }

        private KrakenClient getKrakenClient()
        {

            KrakenApiClientFactory factory = new KrakenApiClientFactory();

            KrakenClient client = factory.GetNewAPIClient();

            return client;
        }
    }
}
