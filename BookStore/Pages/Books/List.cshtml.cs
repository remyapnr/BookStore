using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core;
using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BookStore.Pages.Books
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IBookData bookData;
        public IEnumerable<Book> Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                        IBookData bookData
                        )
        {
            this.config = config;
            this.bookData = bookData;
           
        }
        public void OnGet()
        {
           
            Books = bookData.GetBooksByName(SearchTerm);
        }
    }
}