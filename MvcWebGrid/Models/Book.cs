using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebGrid.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookNm { get; set; }
    }
    public class Order
    {
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public string PaymentMode { get; set; }
        public string city { get; set; }
    }
    public class BookOrdermodel
    {
        public Book book { get; set; }
        public Order order { get; set; }

    }
    public static class BookOrderRepo
    {
        public static IEnumerable<BookOrdermodel> GetBookOrderRepo()
        {
            List<Book> bookList = new List<Book>
        {
            new Book{BookID=1, BookNm="DevCurry.com Developer Tips"},
            new Book{BookID=2, BookNm=".NET and COM for Newbies"},
            new Book{BookID=3, BookNm="51 jQuery ASP.NET Recipes"},
            new Book{BookID=4, BookNm="Motivational Gurus"},
            new Book{BookID=5, BookNm="Spiritual Gurus"}
        };

            List<Order> bookOrders = new List<Order>{
            new Order{OrderID=1, BookID=1, PaymentMode="Cheque",city="kolkata"},
            new Order{OrderID=2, BookID=5, PaymentMode="Credit",city="kolkata"},
            new Order{OrderID=3, BookID=1, PaymentMode="Cash",city="kolkata"},
            new Order{OrderID=4, BookID=3, PaymentMode="Cheque",city="kolkata"},
            new Order{OrderID=5, BookID=3, PaymentMode="Cheque",city="kolkata"},
            new Order{OrderID=6, BookID=4, PaymentMode="Cash",city="kolkata"}
        };
            var orderForBooks = from bk in bookList
                                join ordr in bookOrders
                                on bk.BookID equals ordr.BookID
                                select new BookOrdermodel
                                {

                                    book = bk,
                                    order = ordr
                                };
            return orderForBooks;

        }

        public static IEnumerable<Book> GetBooks()
        {
            List<Book> bookList = new List<Book>
        {
            new Book{BookID=1, BookNm="DevCurry.com Developer Tips"},
            new Book{BookID=2, BookNm=".NET and COM for Newbies"},
            new Book{BookID=3, BookNm="51 jQuery ASP.NET Recipes"},
            new Book{BookID=4, BookNm="Motivational Gurus"},
            new Book{BookID=5, BookNm="Spiritual Gurus"}
        };


            return bookList;

        }
    }




}