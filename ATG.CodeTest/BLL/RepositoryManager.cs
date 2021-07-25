using ATG.CodeTest.Data;
using ATG.CodeTest.Entities;

namespace ATG.CodeTest.BLL
{
    public class RepositoryManager : IRepositoryManager
    {
        private bool _isFailoverModeEnabled = true;
        private int _maxFailedRequests = 50;
        private IRepository _lotRepository;
        private IRepository _archiveRepository;
        private IFailoverRepository _failoverRepository;

        public RepositoryManager(bool isFailoverModeEnabled, int maxFailedRequests, IRepository lotRepository, IRepository archiveRepository, IFailoverRepository failoverRepository)
        {
            _isFailoverModeEnabled = isFailoverModeEnabled;
            _maxFailedRequests = maxFailedRequests;
            _lotRepository = lotRepository;
            _archiveRepository = archiveRepository;
            _failoverRepository = failoverRepository;
        }

        public Lot GetLot(int Id, bool isLotArchived)
        {
            Lot lot;

            if (isLotArchived)
            {
                lot = _archiveRepository.GetLot(Id);
            }
            else if(_isFailoverModeEnabled && _failoverRepository.TenMinuteCount > _maxFailedRequests)
            {
                lot = _failoverRepository.GetLot(Id);
            }
            else
            {
                lot = _lotRepository.GetLot(Id);
            }

            if (lot != null && !isLotArchived && lot.IsArchived)
            {
                lot = _archiveRepository.GetLot(Id);
            }

            return lot;
        }
    }
}
