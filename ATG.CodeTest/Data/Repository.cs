using ATG.CodeTest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
