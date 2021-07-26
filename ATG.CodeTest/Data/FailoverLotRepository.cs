using ATG.CodeTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATG.CodeTest.Data
{
   public class FailoverLotRepository : Repository, IFailoverRepository
    {
        private List<FailoverLot> _failoverLots = null;

        public int TenMinuteCount
        {
            get
            {
                var failoverLots = GetFailOverLotEntries();
                return _failoverLots.Where(failoverLotsEntry => failoverLotsEntry.DateTime != null && failoverLotsEntry.DateTime > DateTime.Now.AddMinutes(-10)).Count();
            }
        }

        private List<FailoverLot> GetFailOverLotEntries()
        {
            // getting all the failover lots not ideal, but given i lack information
            // on how this works (or how many lots are in the store) for now get all
            // and cache them for the GetLot call.
            _failoverLots = _failoverLots ?? new List<FailoverLot>();
            return _failoverLots;
        }

        public override Lot GetLot(int id)
        {
            return (Lot)GetFailOverLotEntries().Where(f => f.Id == id);
        }
    }
}
