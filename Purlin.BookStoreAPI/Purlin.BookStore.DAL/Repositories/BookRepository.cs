using Microsoft.EntityFrameworkCore;
using Purlin.BookStore.DAL.Data;
using Purlin.BookStore.DAL.Interfaces;
using Purlin.BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purlin.BookStore.DAL.Repositories
{
    public class BookRepository : DataService, IBookRepository
    {
        public BookRepository(BookStoreDbContext context) : base(context)
        {
        }

        public async Task<IList<Book>> GetAllAsync()
        {
            return await DbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await DbContext.Books.FindAsync(id);
        }

        public async Task AddAsync(Book book)
        {
            await DbContext.Books.AddAsync(book);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            DbContext.Entry(book).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await DbContext.Books.FindAsync(id);
            DbContext.Books.Remove(book);
            await DbContext.SaveChangesAsync();
        }
    }

}
