using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core;
using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookData bookData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }

        public EditModel(IBookData bookData,
                        IHtmlHelper htmlHelper)
        {
            this.bookData = bookData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? bookId)
        {
            Types = htmlHelper.GetEnumSelectList<BookType>();
            if (bookId.HasValue)
            {
                Book = bookData.GetById(bookId.Value);
            }
            else
            {
                Book = new Book();
            }
            if (Book == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Types = htmlHelper.GetEnumSelectList<BookType>();
                return Page();
            }

            if (Book.Id > 0)
            {
                bookData.Update(Book);
            }
            else
            {
                bookData.Add(Book);
            }
            bookData.Commit();
            TempData["Message"] = "Book saved!";
            return RedirectToPage("./Detail", new { bookId = Book.Id });
        }
    }
}