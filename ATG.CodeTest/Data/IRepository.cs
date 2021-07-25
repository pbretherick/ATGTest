using ATG.CodeTest.Entities;

namespace ATG.CodeTest.Data
{
    public interface IRepository
    {
        public Lot GetLot(int id);
    }
}
