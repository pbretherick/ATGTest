using ATG.CodeTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATG.CodeTest.Data
{
   public class FailoverLotRepository : Repository, IFailoverRepository
    {
        private List<FailoverLots> _failoverLots = null;

        public int TenMinuteCount
        {
            get
            {
                var failoverLots = GetFailOverLotEntries();
                return _failoverLots.Where(failoverLotsEntry => failoverLotsEntry.DateTime > DateTime.Now.AddMinutes(-10)).Count();
            }
        }

        private List<FailoverLots> GetFailOverLotEntries()
        {
            // return all from fail entries from database
            _failoverLots = _failoverLots ?? new List<FailoverLots>();
            return _failoverLots;
        }

        public override Lot GetLot(int id)
        {
            return (Lot)GetFailOverLotEntries().Where(f => f.Id == id);
        }
    }
}
