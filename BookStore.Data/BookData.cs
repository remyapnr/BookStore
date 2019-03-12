using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Core;

namespace BookStore.Data
{
    public class BookData : IBookData
    {
        readonly List<Book> books;
        public BookData()
        {
            books = new List<Book>()
            {
                new Book { Id = 1, Name = "1984", Author="George Orwell", Type=BookType.Fiction},
                new Book { Id = 2, Name = "Harry Potter and the Sorcerer's Stone", Author="J.K. Rowling", Type=BookType.Fiction},
                new Book { Id = 3, Name = "The Hunger Games", Author = " Suzanne Collins", Type=BookType.Fiction},
                 new Book { Id = 4, Name = "The Da Vinci Code", Author = "Dan Brown", Type=BookType.Fiction},
                  new Book { Id = 5, Name = "The Diary of a Young Girl", Author = "Anne Frank", Type=BookType.NonFiction},
                   new Book { Id = 6, Name = "A Brief History of Time", Author = " Stephen Hawking", Type=BookType.NonFiction},
                    new Book { Id = 7, Name = "The Power of Habit", Author = " Charles Duhigg", Type=BookType.NonFiction},
                     new Book { Id = 8, Name = "Thinking, Fast and Slow", Author = " Daniel Kahneman", Type=BookType.NonFiction}
            };
        }

        public Book Add(Book newBook)
        {
            books.Add(newBook);
            newBook.Id = books.Max(r => r.Id) + 1;
            return newBook;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Book> GetBooksByName(string name)
        {
            return from b in books
                   where string.IsNullOrEmpty(name) ||b.Name.StartsWith(name)
                   orderby b.Name
                   select b;
        }

        public Book GetById(int id)
        {
            return books.SingleOrDefault(r => r.Id == id);
        }

        public Book Update(Book updatedBook)
        {
            var book = books.SingleOrDefault(r => r.Id == updatedBook.Id);
            if (book != null)
            {
                book.Name = updatedBook.Name;
                book.Author = updatedBook.Author;
                book.Type = updatedBook.Type;
            }
            return book;
        }

        IEnumerable<Book> IBookData.GetAll()
        {
            return  from b in books orderby b.Name
                    select b;

        }
    }
}
