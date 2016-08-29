using SeaMist;
using SeaMist.Http;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraken
{
    public class KrakenApiClientFactory
    {

        public KrakenClient GetNewAPIClient()
        {
            string apiKey = ConfigurationManager.AppSettings["krakenApiKey"];
            string apiSecret = ConfigurationManager.AppSettings["krakenApiSecret"];

            KrakenConnection apiConnection = createApiConnection(apiKey, apiSecret);
            KrakenClient client = new KrakenClient(apiConnection);
            return client;
        }

        private KrakenConnection createApiConnection(string apiKey, string secret)
        {
            KrakenConnection connection = KrakenConnection.Create(apiKey, secret);
            return connection;
        }

    }
}
