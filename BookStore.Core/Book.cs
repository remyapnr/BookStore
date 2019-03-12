using System;

namespace BookStore.Core
{
   
    public class Book
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public BookType Type { get; set; }
    }
}
