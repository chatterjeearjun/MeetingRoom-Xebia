using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ttf.BusinessLayer.Foo.Dto;

namespace Ttf.BusinessLayer.Foo
{
    /// <summary>
    /// Implementation of Strategy pattern to swap calculation formulas based on <paramref name="provider"/>.
    /// <para/>
    /// New <see cref="IFooCalculator"/> instances can be added via dependency injection without 
    /// changing the design of <see cref="FooCalculatorStrategy"/> or any
    /// existing <see cref="IFooCalculator"/> implementations.
    /// </summary>
    public class FooCalculatorStrategy : IFooCalculatorStrategy
    {
        private readonly IFooCalculator[] calculators;

        public FooCalculatorStrategy(IFooCalculator[] calculators)
        {
            if (calculators == null)
                throw new ArgumentNullException("calculators");
            this.calculators = calculators;
        }

        public List<RoomsFeatures> GetInitialRoomAndFeatureData( string provider)
        {

            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException("provider");
            }

            var calculator = calculators.Where(x => x.AppliesTo(provider)).FirstOrDefault();

            if (calculator == null)
            {
                throw new ArgumentException("Provider '" + provider + "' is not valid or is not registered.");
            }

            return calculator.GetInitialRoomAndFeatureData(provider);
        }

        public List<Features> GetInitialFeatureData( string provider)
        {

            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException("provider");
            }

            var calculator = calculators.Where(x => x.AppliesTo(provider)).FirstOrDefault();

            if (calculator == null)
            {
                throw new ArgumentException("Provider '" + provider + "' is not valid or is not registered.");
            }

            return calculator.GetInitialFeatureData(provider);
        }

        public List<Rooms> GetInitialRoomData( string provider)
        {

            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException("provider");
            }

            var calculator = calculators.Where(x => x.AppliesTo(provider)).FirstOrDefault();

            if (calculator == null)
            {
                throw new ArgumentException("Provider '" + provider + "' is not valid or is not registered.");
            }

            return calculator.GetInitialRoomData(provider);
        }


        public Task<List<DataAccess.Entities.IntialResponse>> GetInitialData(string provider)
        {

            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException("provider");
            }

            var calculator = calculators.Where(x => x.AppliesTo(provider)).FirstOrDefault();

            if (calculator == null)
            {
                throw new ArgumentException("Provider '" + provider + "' is not valid or is not registered.");
            }

            return calculator.GetInitialData(provider);
        }
        public int SaveRoomBokingDetails()
        {
            var calculator = calculators.Where(x => x.AppliesTo("base")).FirstOrDefault();

            if (calculator == null)
            {
                throw new ArgumentException("Provider '" + "" + "' is not valid or is not registered.");
            }
            return calculator.SaveRoomBokingDetails();
        }
    }
}
