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
        private readonly IDataRepository<BikeSeller, int> dataRepository;
        public BikeSellerBusinessService(IDataRepository<BikeSeller, int> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public Task<long> Add(BikeSeller bikeSeller)
        {
            return dataRepository.Add(bikeSeller);
        }

        public Task<long> Delete(int id)
        {
            return dataRepository.Delete(id);
        }

        public IEnumerable<BikeSeller> GetAll()
        {
            return dataRepository.GetAll();
        }

        public Task<long> Update(int id, BikeSeller bikeSeller)
        {
            if (bikeSeller.Status.Equals(BikeSellerStatusType.deactivated))
            {
                bikeSeller.CalculateNewComission();
            }
            
            return dataRepository.Update(id, bikeSeller);
        }
    }
}
