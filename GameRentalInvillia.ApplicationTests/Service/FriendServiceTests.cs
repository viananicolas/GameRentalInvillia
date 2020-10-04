using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Friend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameRentalInvillia.ApplicationTests.Service
{
    [TestClass()]
    public class FriendServiceTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var mock = new Mock<IFriendService>();
            mock.Setup(e => e.GetAll()).Returns(new List<FriendViewModel>() {
                new FriendViewModel
                {
                    Address = "1", Email = "2@w.com", FullName = "Fulano", Id = Guid.NewGuid(), TelephoneNumber = "1234"
                }});
            Assert.IsTrue(mock.Object.GetAll().Any());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var mock = new Mock<IFriendService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.GetById(guid)).Returns(Task.FromResult(new FriendViewModel
            {
                Address = "1",
                Email = "2@w.com",
                FullName = "Fulano",
                Id = guid,
                TelephoneNumber = "1234"
            }));
            var result = mock.Object.GetById(guid).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AddTest()
        {
            var mock = new Mock<IFriendService>();
            var friendFormViewModel = new FriendFormViewModel
            {
                Address = "1",
                Email = "2@w.com",
                FullName = "Fulano",
                TelephoneNumber = "1234"
            };
            mock.Setup(e => e.Add(friendFormViewModel));
            mock.Object.Add(friendFormViewModel);
        }

        [TestMethod()]
        public void UpdateByIdTest()
        {
            var mock = new Mock<IFriendService>();
            var guid = Guid.NewGuid();
            var friendFormViewModel = new FriendFormViewModel
            {
                Address = "1",
                Email = "2@w.com",
                FullName = "Fulano",
                TelephoneNumber = "1234"
            };
            mock.Setup(e => e.UpdateById(guid, friendFormViewModel));
            mock.Object.UpdateById(guid, friendFormViewModel);
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            var mock = new Mock<IFriendService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.DeleteById(guid));
            mock.Object.DeleteById(guid);
        }
    }
}