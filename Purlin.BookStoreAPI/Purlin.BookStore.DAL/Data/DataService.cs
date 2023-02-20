using Purlin.BookStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purlin.BookStore.DAL.Data
{
    public abstract class DataService : IDataService
    {
        protected bool Disposed;
        public DataService(BookStoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                DbContext?.Dispose();

                Disposed = true;
            }
        }

        public BookStoreDbContext DbContext { get; }
    }
}
