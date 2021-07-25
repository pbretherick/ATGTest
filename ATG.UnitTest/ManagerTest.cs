using ATG.CodeTest;
using ATG.CodeTest.BLL;
using ATG.CodeTest.Data;
using Moq;
using NUnit.Framework;

namespace ATG.UnitTest
{
    class ManagerTest
    {
        [TestCase(false, 0, true, true)]
        [TestCase(false, 0, false, true)]
        [TestCase(false, 0, true, false)]
        [TestCase(false, 0, false, false)]
        [TestCase(true, 20, false, false)]
        [TestCase(true, 70, false, false)]
        [TestCase(false, 20, false, false)]
        [TestCase(false, 70, false, false)]
        public void Manage_Calls_Correct_Repository(bool isFailoverModeEnabled, int maxFailedRequests, bool isArchived, bool isLotArchived)
        {
            var lot = new CodeTest.Entities.Lot() { Id = 1, Name = "Lot", IsArchived = isLotArchived };
            var archivedLot = new CodeTest.Entities.Lot() { Id = 2, Name = "Archived Lot", IsArchived = isLotArchived };
            var failoverLot = new CodeTest.Entities.Lot() { Id = 3, Name = "Failover Lot", IsArchived = isLotArchived };

            var moqLotRepository = new Mock<IRepository>();
            var moqArchiveRepository = new Mock<IRepository>();
            var moqFailoverRepository = new Mock<IFailoverRepository>();

            moqLotRepository.Setup(m => m.GetLot(It.IsAny<int>())).Returns(lot);
            moqArchiveRepository.Setup(m => m.GetLot(It.IsAny<int>())).Returns(archivedLot);
            moqFailoverRepository.Setup(m => m.GetLot(It.IsAny<int>())).Returns(failoverLot);
            moqFailoverRepository.Setup(m => m.TenMinuteCount).Returns(50);

            var repositoryManager = new RepositoryManager(isFailoverModeEnabled, maxFailedRequests, moqLotRepository.Object, moqArchiveRepository.Object, moqFailoverRepository.Object);

            var result = repositoryManager.GetLot(1, isArchived);

            if (isArchived || isLotArchived)
            {
                moqArchiveRepository.Verify(m => m.GetLot(It.IsAny<int>()), Times.Once);
                Assert.AreSame(archivedLot, result);
            }
            else if (isFailoverModeEnabled && 50 > maxFailedRequests)
            {
                moqFailoverRepository.Verify(m => m.GetLot(It.IsAny<int>()), Times.Once);
                Assert.AreSame(failoverLot, result);
            }
            else
            {
                moqLotRepository.Verify(m => m.GetLot(It.IsAny<int>()), Times.Once);
                Assert.AreSame(lot, result);
            }
        }
    }
}
