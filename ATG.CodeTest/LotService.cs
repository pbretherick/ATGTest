using ATG.CodeTest.BLL;
using ATG.CodeTest.Entities;

namespace ATG.CodeTest
{
    public class LotService
    {
        private IRepositoryManager _repositoryManager = null;

        public LotService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Lot GetLot(int id, bool isLotArchived)
        {
            return _repositoryManager.GetLot(id, isLotArchived);
        }
    }
}
