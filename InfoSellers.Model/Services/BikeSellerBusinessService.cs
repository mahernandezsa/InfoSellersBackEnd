using InfoSellers.Model.Entities;
using InfoSellers.Model.Enums;
using InfoSellers.Model.Exceptions;
using InfoSellers.Model.Repository;
using Newtonsoft.Json.Linq;
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

        public async Task<long> Add(BikeSeller bikeSeller)
        {
            try
            {
                return await _dataRepository.Add(bikeSeller);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(500, @"Internal error: " + ex.Message);
            }

        }

        public async Task<long> Delete(int id)
        {
            try
            {                
                return await _dataRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(500, @"Internal error: " + ex.Message);
            }
        }

        public IEnumerable<BikeSeller> GetAll()
        {
            try
            {
                return _dataRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(500, @"Internal error: " + ex.Message);
            }
        }

        public async Task<long> Update(int id, BikeSeller bikeSeller)
        {
            try
            {
                if (id != bikeSeller.Id || bikeSeller.Role.Id != bikeSeller.RoleId)                
                    throw new HttpResponseException(400, @"There is not match between Id property of BikeSeller/Role");
                
                if (bikeSeller.Status.Equals(BikeSellerStatusType.deactivated))                
                    bikeSeller.CalculateNewComission();
                
                return await _dataRepository.Update(id, bikeSeller);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(500, @"Internal error: " + ex.Message);
            }
        }

        public async Task<BikeSeller> GetById(int id)
        {
            try
            {
                var bikeSeller = await _dataRepository.GetById(id);
                return bikeSeller;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(500, @"Internal error: " + ex.Message);
            }
        }



    }
}
