using System;
using System.Collections.Generic;
using System.Text;

namespace ATG.CodeTest.Data
{
    public interface IFailoverRepository : IRepository
    {
        int TenMinuteCount { get; }
    }
}
