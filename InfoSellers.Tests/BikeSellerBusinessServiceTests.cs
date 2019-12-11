using InfoSellers.Model.Entities;
using InfoSellers.Model.Enums;
using InfoSellers.Model.Repository;
using InfoSellers.Model.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InfoSellers.Tests
{
    public class BikeSellerBusinessServiceTests
    {
        private IEnumerable<BikeSeller> GetAllBikeSellersListMock()
        {

            var sessions = new List<BikeSeller>
            {
                new BikeSeller()
                {
                    Address= "4234wedwr3",
                    FullName= "asdsada daadad",
                    Id= 3,
                    NIT= "222222222",
                    PenaltyPercentage = 45,
                    Phone = 34234234,
                    Role = new Role(){ Id= 2, RoleName="Role 2", CommissionType = RoleCommissionType.junior, ComissionValue= 990 },
                    RoleId = 2,
                    Status= BikeSellerStatusType.activated
                },
                new BikeSeller()
                {
                    Address= "4234wedwr3",
                    FullName= "asdsada daadad",
                    Id= 3,
                    NIT= "222222222",
                    PenaltyPercentage = 45,
                    Phone = 34234234,
                    Role = new Role(){ Id= 2, RoleName="Role 2", CommissionType = RoleCommissionType.junior, ComissionValue= 990 },
                    RoleId = 2,
                    Status= BikeSellerStatusType.activated
                }
            };
            return sessions;
        }

        [Fact(DisplayName = "When API has BikeSellers should return them")]
        public void GetAllBikeSeller_APIAvailable_ShouldWork()
        {

            //Arrange
            var bikeSellerRepositoryMock = new Mock<IDataRepository<BikeSeller, int>>();
            bikeSellerRepositoryMock.Setup(c => c.GetAll()).Returns(GetAllBikeSellersListMock().AsQueryable());

            var bikeSellerService = new BikeSellerBusinessService(bikeSellerRepositoryMock.Object);
            //Act

            var result = bikeSellerService.GetAll();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<BikeSeller>>(result);
            Assert.NotEmpty(result);
        }
    }
}
