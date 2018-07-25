using AutoMapper;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Ttf.BusinessLayer.Foo;
using Ttf.BusinessLayer.Foo.Dto;
using Ttf.WebApi.Models;

namespace Ttf.WebApi.Controllers
{
    [ApiVersion("1")]
    public class FooController : ApiController
    {
        private readonly IFooCalculatorStrategy fooCalculatorStrategy;
        private readonly IMapper mapper;
        public FooController(IMapper mapper, IFooCalculatorStrategy fooCalculatorStrategy)
        {
            if (mapper == null)
                throw new ArgumentNullException("mapper");
            if (fooCalculatorStrategy == null)
                throw new ArgumentNullException("fooCalculatorStrategy");

            this.mapper = mapper;
            this.fooCalculatorStrategy = fooCalculatorStrategy;
        }

        [Route("api/v{version:apiVersion}/foo")]
        public HttpResponseMessage GetPrimaryData( [FromUri] string provider = "base")
        {
            provider = string.IsNullOrWhiteSpace(provider) ? ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString : provider;
            var getRoomResult = this.fooCalculatorStrategy.GetInitialRoomData(provider);
            //var Room = this.mapper.Map<List<Rooms>>(getRoomResult);
            //var getFeatureResult = this.fooCalculatorStrategy.GetInitialFeatureData( provider);
            //var Feature = this.mapper.Map< List<Features>>(getFeatureResult);
            //var getRoomFeaturesResult = this.fooCalculatorStrategy.GetInitialRoomAndFeatureData( provider);
            //var RoomFeatureMapping = this.mapper.Map< List<RoomsFeatures>>(getRoomFeaturesResult);
            //var getIntialResponse = this.mapper.Map<IntialResponse>(new IntialResponse { RoomList = Room , FeatureList = Feature, MappingList = RoomFeatureMapping});

            var getIntialResponse = PrimaryData();
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                if (session["initialData"] == null)
                session["initialData"] = getIntialResponse;
            }
            return Request.CreateResponse(HttpStatusCode.OK, getIntialResponse);
        }

        public async Task<List<DataAccess.Entities.IntialResponse>> PrimaryData([FromUri] string provider = "base")
        {
            return await this.fooCalculatorStrategy.GetInitialData(provider);
        }

        [Route("api/v{version:apiVersion}/roomFilteredData")]
        public HttpResponseMessage Get([FromUri] string provider = "base")
        {
            var calculatorRequest = ((System.Collections.Generic.KeyValuePair<string, string>[])this.Request.GetQueryNameValuePairs())[0].Value;
            GridFilterDataOfRoom gfr = new GridFilterDataOfRoom();
            gfr.RoomID = Convert.ToInt32(calculatorRequest);
            if(gfr.RoomID != 0)
            { 
            var initialData = (IntialResponse)HttpContext.Current.Session["initialData"];
            gfr.RoomName = initialData.RoomList.Where(x => x.RoomID == gfr.RoomID).Single().RoomName;
            foreach (RoomsFeatures i in initialData.MappingList)
            {
                if (i.RoomID == gfr.RoomID)
                {
                    gfr.Features.Add(new FeatureResults { FeatureID = i.FeatureID, FeatureName = i.FeatureName });
                }                
            }
            }
            return Request.CreateResponse(HttpStatusCode.OK, gfr);
        }

        [Route("api/v{version:apiVersion}/featureFilteredData")]
        public HttpResponseMessage featureFilteredData([FromUri] Features request, [FromUri] string provider = "base")
        {
            var calculatorRequest = this.mapper.Map<Features>(request);
            GridFilterDataOfFeature gfr = new GridFilterDataOfFeature();
            gfr.FeatureID = calculatorRequest.FeatureID;
            if (gfr.FeatureID != 0)
            {
                var initialData = (IntialResponse)HttpContext.Current.Session["initialData"];
                gfr.FeatureName = initialData.FeatureList.Where(x => x.FeatureID == gfr.FeatureID).Single().FeatureName;
                foreach (RoomsFeatures i in initialData.MappingList)
                {
                    if (i.FeatureID == gfr.FeatureID)
                    {
                        gfr.Rooms.Add(new RoomResults { RoomID = i.RoomID, RoomName = i.RoomName });
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, gfr);
        }

        public HttpResponseMessage Post([FromBody] RoomConfirmBooking roomdata)
        {
            try
            {
                var message = Request.CreateResponse(HttpStatusCode.Created, roomdata);
                message.Headers.Location = new Uri(Request.RequestUri + Convert.ToString(roomdata.RoomID));
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }
    }
}
