using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Rental;
using GameRentalInvillia.Core.Common.Enum;
using GameRentalInvillia.Core.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameRentalInvillia.ApplicationTests.Service
{
    [TestClass()]
    public class RentalServiceTests
    {

        [TestMethod()]
        public void GetAllTest()
        {
            var mock = new Mock<IRentalService>();
            mock.Setup(e => e.GetAll()).Returns(new List<RentalViewModel>() {
                new RentalViewModel
                {
                    FriendName = "a",
                    GameName = "A",
                    Id = Guid.NewGuid(),
                    Platform = Platform.PS2.GetDescription(),
                    RentalDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(5)
                }});
            Assert.IsTrue(mock.Object.GetAll().Any());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var mock = new Mock<IRentalService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.GetById(guid)).Returns(Task.FromResult(new RentalViewModel
            {
                FriendName = "a",
                GameName = "A",
                Id = guid,
                Platform = Platform.PS2.GetDescription(),
                RentalDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(5)
            }));
            var result = mock.Object.GetById(guid).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AddTest()
        {
            var mock = new Mock<IRentalService>();
            var rentalFormViewModel = new RentalFormViewModel
            {
                FriendId = Guid.NewGuid(),
                GameId = Guid.NewGuid(),
                RentalDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(5)
            };
            mock.Setup(e => e.Add(rentalFormViewModel));
            mock.Object.Add(rentalFormViewModel);
        }

        [TestMethod()]
        public void UpdateByIdTest()
        {
            var mock = new Mock<IRentalService>();
            var guid = Guid.NewGuid();
            var rentalFormViewModel = new RentalFormViewModel
            {
                FriendId = Guid.NewGuid(),
                GameId = Guid.NewGuid(),
                RentalDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(5)
            };
            mock.Setup(e => e.UpdateById(guid, rentalFormViewModel));
            mock.Object.UpdateById(guid, rentalFormViewModel);
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            var mock = new Mock<IRentalService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.DeleteById(guid));
            mock.Object.DeleteById(guid);
        }
    }
}