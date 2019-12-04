using InfoSellers.Model.Entities;
using InfoSellers.Model.Enums;
using InfoSellers.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Model.Services
{
    public class BikeSellerBusinessService : IBusinessService<BikeSeller, int>
    {
        private readonly IDataRepository<BikeSeller, int> _dataRepository;
        public BikeSellerBusinessService(IDataRepository<BikeSeller, int> _dataRepository)
        {
            this._dataRepository = _dataRepository ?? throw new ArgumentNullException(nameof(_dataRepository));
        }

        public Task<long> Add(BikeSeller bikeSeller)
        {
            return _dataRepository.Add(bikeSeller);
        }

        public Task<long> Delete(int id)
        {
            return _dataRepository.Delete(id);
        }

        public IEnumerable<BikeSeller> GetAll()
        {
            return _dataRepository.GetAll();
        }

        public Task<long> Update(int id, BikeSeller bikeSeller)
        {
            if (bikeSeller.Status.Equals(BikeSellerStatusType.deactivated))
            {
                bikeSeller.CalculateNewComission();
            }
            
            return _dataRepository.Update(id, bikeSeller);
        }

        public async Task<BikeSeller> GetById(int id)
        {
            var bikeSeller = await _dataRepository.GetById(id);

            return bikeSeller;
        }



    }
}
