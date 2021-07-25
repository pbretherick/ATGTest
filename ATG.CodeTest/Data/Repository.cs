using ATG.CodeTest.Entities;

namespace ATG.CodeTest.Data
{
    public abstract class Repository : IRepository
    {
        public virtual Lot GetLot(int id)
        {
            return new Lot();
        }
    }
}
