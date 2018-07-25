using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRoomsRepository _RoomsRepository;
        public UnitOfWork(IRoomsRepository RoomsRepository)
        {
            _RoomsRepository = RoomsRepository;
        }
        public IRoomsRepository RoomsRepository
        {
            get
            {
                return _RoomsRepository;
            }
        }

        private readonly IRoomsFeatureRepository _RoomsFeatureRepository;
        public UnitOfWork(IRoomsFeatureRepository RoomsFeatureRepository)
        {
            _RoomsFeatureRepository = RoomsFeatureRepository;
        }
        public IRoomsFeatureRepository RoomsFeatureRepository
        {
            get
            {
                return _RoomsFeatureRepository;
            }
        }

        private readonly IInitialResponseRepository _InitialResponseRepository;
        public UnitOfWork(IInitialResponseRepository InitialResponseRepository)
        {
            _InitialResponseRepository = InitialResponseRepository;
        }
        public IInitialResponseRepository InitialResponseRepository
        {
            get
            {
                return _InitialResponseRepository;
            }
        }

        private readonly IFeaturesRepository _FeaturesRepository;
        public UnitOfWork(IFeaturesRepository FeaturesRepository)
        {
            _FeaturesRepository = FeaturesRepository;
        }
        public IFeaturesRepository FeaturesRepository
        {
            get
            {
                return _FeaturesRepository;
            }
        }

        private readonly IConfirmBookingRepository _ConfirmBookingRepository;
        public UnitOfWork(IConfirmBookingRepository blogRepository)
        {
            _ConfirmBookingRepository = blogRepository;
        }
        public IConfirmBookingRepository ConfirmBookingRepository
        {
            get
            {
                return _ConfirmBookingRepository;
            }
        }
        void IUnitOfWork.Complete()
        {
            throw new NotImplementedException();
        }          
        
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
