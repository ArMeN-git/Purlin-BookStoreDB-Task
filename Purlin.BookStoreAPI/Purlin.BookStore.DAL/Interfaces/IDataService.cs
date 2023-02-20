using Purlin.BookStore.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purlin.BookStore.DAL.Interfaces
{
    public interface IDataService : IDisposable
    {
        BookStoreDbContext DbContext { get; }
    }
}
