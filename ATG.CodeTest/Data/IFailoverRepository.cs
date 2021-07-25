namespace ATG.CodeTest.Data
{
    public interface IFailoverRepository : IRepository
    {
        int TenMinuteCount { get; }
    }
}
