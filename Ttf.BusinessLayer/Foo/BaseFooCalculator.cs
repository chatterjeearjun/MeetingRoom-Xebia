using System;
using System.Collections.Generic;
using Ttf.BusinessLayer.Foo.Dto;
using DataAccess.Services;
using System.Threading.Tasks;

namespace Ttf.BusinessLayer.Foo
{
    /// <summary>
    /// Base class for our calculator. This class can be subclassed as necessary to customize behavior.
    /// </summary>
    public class BaseFooCalculator : IFooCalculator
    {
        IConfirmBookingService _confirmBookingService;
        IFeaturesService _featuresService;
        IInitialResponseService _initialResponseService;
        IRoomsFeatureService _roomsFeatureService;
        IRoomsService _roomsService;
        public BaseFooCalculator(IConfirmBookingService confirmBookingService, IFeaturesService featuresService, IInitialResponseService initialResponseService,
            IRoomsFeatureService roomsFeatureService, IRoomsService roomsService)
        {
            _confirmBookingService = confirmBookingService;
            _featuresService = featuresService;
            _initialResponseService = initialResponseService;
            _roomsFeatureService = roomsFeatureService;
            _roomsService = roomsService;
        }

        //public async Task<RoomConfirmBooking> GetAllBlogPostsByPageIndex()
        //{
        //    var resultData = await _confirmBookingService.GetAllBlogByPageIndex(3, 4);
        //    return resultData;
        //}
        private readonly string provider;

        public BaseFooCalculator()
        {
            // Load our provider name via Reflection.
            // Note that subclasses will get their own name, not the base controller,
            // but they must follow the correct naming convention for this to work.
            this.provider = this.GetType().Name.Replace("FooCalculator", string.Empty);
        }

        public virtual bool AppliesTo(string provider)
        {
            return this.provider.Equals(provider, StringComparison.OrdinalIgnoreCase);
        }

        public List<Rooms> GetInitialRoomData(string provider)
        {
            //var x = GetX(request);
            return new List<Rooms>()
            {
                new Rooms{ RoomID=101,RoomName="ABC"},
                new Rooms{ RoomID=102,RoomName="DEF"},
                new Rooms{ RoomID=103,RoomName="GHI"}
            };
        }

        public Task<List<DataAccess.Entities.IntialResponse>> GetInitialData(string provider)
        {
            var resultData = _initialResponseService.GetAllBlogByPageIndex(3, 4);
            return resultData;
        }

        public virtual List<Features> GetInitialFeatureData(string provider)
        {
            return new List<Features>()
            {
                new Features{ FeatureID=101,FeatureName="ABCv"},
                new Features{ FeatureID=102,FeatureName="DEFv"},
                new Features{ FeatureID=103,FeatureName="GHIv"}
            };
        }

        public virtual List<RoomsFeatures> GetInitialRoomAndFeatureData(string provider)
        {
            return new List<RoomsFeatures>()
            {

            };
        }

        public virtual int SaveRoomBokingDetails()
        {
            int i = 0;

            return i;

        }
    }
}
