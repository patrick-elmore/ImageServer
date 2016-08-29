using ImageProcessingServer.Models.JSON;
using Kraken;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ImageProcessingServer.Controllers
{
    public class CompressionController : ApiController
    {
        [HttpPost]
        [Route("compression/lossless")]

        public HttpResponseMessage Lossless(CompressionRequest request)
        {
            string imgUrl = request.imageUrl;

            KrakenService service = new KrakenService();

            string optimizedImageUrl = service.GetLosslessImage(imgUrl);

            StringContent content = new StringContent(optimizedImageUrl);

            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        [HttpPost]
        [Route("compression/lossy")]

        public HttpResponseMessage Lossy(CompressionRequest request)
        {
            string imgUrl = request.imageUrl;

            KrakenService service = new KrakenService();

            string optimizedImageUrl = service.GetLossyImage(imgUrl);

            dynamic json = new ExpandoObject();

            json.ImageUrl = optimizedImageUrl;

            string content = JsonConvert.SerializeObject(json);

            return Request.CreateResponse(HttpStatusCode.OK, content);
        }
    }
}