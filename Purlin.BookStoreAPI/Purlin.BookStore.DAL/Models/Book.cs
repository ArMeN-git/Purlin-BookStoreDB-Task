using System;
using System.Collections.Generic;

namespace Purlin.BookStore.DAL.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Isbn { get; set; }

    public int? NumPages { get; set; }

    public DateTime? PublicationDate { get; set; }

    public virtual ICollection<Author> Authors { get; } = new List<Author>();
}
