using InfoSellers.Model.Entities;
using InfoSellers.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Model.Services
{
    public class RoleBusinessService : IBusinessService<Role, int>
    {
        private readonly IDataRepository<Role, int> _dataRepository;
        public RoleBusinessService(IDataRepository<Role, int> _dataRepository)
        {
            this._dataRepository = _dataRepository ?? throw new ArgumentNullException(nameof(_dataRepository));
        }

        public async Task<long> Add(Role role)
        {
            return await _dataRepository.Add(role);
        }

        public async Task<long> Delete(int id)
        {
            return await _dataRepository.Delete(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _dataRepository.GetAll();
        }

        public async Task<long> Update(int id, Role role)
        {
            return await _dataRepository.Update(id, role);
        }

        public async Task<Role> GetById(int id)
        {
            var role = await _dataRepository.GetById(id);

            return role;
        }



    }
}


