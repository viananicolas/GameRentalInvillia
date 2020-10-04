using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Game;
using GameRentalInvillia.Core.Common.Enum;
using GameRentalInvillia.Core.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameRentalInvillia.ApplicationTests.Service
{
    [TestClass()]
    public class GameServiceTests
    {

        [TestMethod()]
        public void GetAllTest()
        {
            var mock = new Mock<IGameService>();
            mock.Setup(e => e.GetAll()).Returns(new List<GameViewModel>() {
                new GameViewModel
                {
                    GameName = "A",
                    Developer = "AA",
                    Publisher = "AAA",
                    Id = Guid.NewGuid(),
                    Platform = Platform.PS1.GetDescription(),
                    ReleaseYear = 2000
                }});
            Assert.IsTrue(mock.Object.GetAll().Any());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var mock = new Mock<IGameService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.GetById(guid)).Returns(Task.FromResult(new GameViewModel
            {
                GameName = "A",
                Developer = "AA",
                Publisher = "AAA",
                Id = Guid.NewGuid(),
                Platform = Platform.PS1.GetDescription(),
                ReleaseYear = 2000
            }));
            var result = mock.Object.GetById(guid).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AddTest()
        {
            var mock = new Mock<IGameService>();
            var gameFormViewModel = new GameFormViewModel
            {
                GameName = "A",
                Developer = "AA",
                Publisher = "AAA",
                Platform = Platform.PS1,
                ReleaseYear = 2000
            };
            mock.Setup(e => e.Add(gameFormViewModel));
            mock.Object.Add(gameFormViewModel);
        }

        [TestMethod()]
        public void UpdateByIdTest()
        {
            var mock = new Mock<IGameService>();
            var guid = Guid.NewGuid();
            var gameFormViewModel = new GameFormViewModel
            {
                GameName = "A",
                Developer = "AA",
                Publisher = "AAA",
                Platform = Platform.PS1,
                ReleaseYear = 2000
            };
            mock.Setup(e => e.UpdateById(guid, gameFormViewModel));
            mock.Object.UpdateById(guid, gameFormViewModel);
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            var mock = new Mock<IGameService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.DeleteById(guid));
            mock.Object.DeleteById(guid);
        }
    }
}