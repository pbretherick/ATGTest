using ATG.CodeTest;
using ATG.CodeTest.BLL;
using Moq;
using NUnit.Framework;

namespace ATG.UnitTest
{
    public class ServiceTest
    {
        [Test]
        public void Service_Calls_Manager()
        {
            var id = 1;
            var isLotArchived = true;

            // Given I have setup my manager and service
            var moqRepositoryManager = new Mock<IRepositoryManager>();
            var lotService = new LotService(moqRepositoryManager.Object);

            // When I call the service
            lotService.GetLot(id, isLotArchived);

            // Then i expect GetLot was called once with the correct parameters
            moqRepositoryManager.Verify(m => m.GetLot(id, isLotArchived), Times.Once);
        }
    }
}