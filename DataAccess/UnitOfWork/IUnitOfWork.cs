using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IConfirmBookingRepository ConfirmBookingRepository { get; }
        IFeaturesRepository FeaturesRepository { get; }
        IInitialResponseRepository InitialResponseRepository { get; }
        IRoomsFeatureRepository RoomsFeatureRepository { get; }
        IRoomsRepository RoomsRepository { get; }

        void Complete();
    }
}
