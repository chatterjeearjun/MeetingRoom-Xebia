using System.Collections.Generic;
using System.Threading.Tasks;
using Ttf.BusinessLayer.Foo.Dto;

namespace Ttf.BusinessLayer.Foo
{
    public interface IFooCalculator
    {
        bool AppliesTo(string provider);
        List<Rooms> GetInitialRoomData(string provider);
        List<Features> GetInitialFeatureData(string provider);
        List<RoomsFeatures> GetInitialRoomAndFeatureData(string provider);
        Task<List<DataAccess.Entities.IntialResponse>> GetInitialData(string provider);
        int SaveRoomBokingDetails();
    }
}
