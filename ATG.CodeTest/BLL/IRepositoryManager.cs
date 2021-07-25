using ATG.CodeTest.Entities;

namespace ATG.CodeTest.BLL
{
    public interface IRepositoryManager
    {
        public Lot GetLot(int Id, bool isLotArchived);
    }
}
