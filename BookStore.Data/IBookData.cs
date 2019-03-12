using BookStore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data
{
   public interface IBookData
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksByName(string name);
        Book GetById(int id);
        Book Update(Book updatedBook);
        Book Add(Book newBook);
        int Commit();
    }
   
}
