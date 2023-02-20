using System;
using System.Collections.Generic;

namespace Purlin.BookStore.DAL.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
