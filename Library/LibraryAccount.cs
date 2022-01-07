using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class LibraryAccount
    {
        private Reader owner;
        private List<Book> borrowed; // מושאלים 
        private List<Book> invited; // מוזמנים
        private double debts;

        public LibraryAccount(Reader AccountOwner)
        {
            owner = AccountOwner;
            invited = new List<Book>();
            borrowed = new List<Book>();
            debts = 0;
        }
        public Reader Owner { get => owner; set => owner = value; }
        public List<Book> Invited { get => invited; set => invited = value; }
        public List<Book> Borrowed { get => borrowed; set => borrowed = value; }
        public double Debts { get => debts; set => debts = value; } 
        public bool invited_Book_From_Library(Book book)
        {
            if (this.debts > 0) { throw new InvalidOperationException("debts > 0"); }// debts
            // VALIDATION #1 - if the customer already has this book
            if (this.owner.Type.ToString() != book.Type.ToString()){throw new InvalidOperationException("this.owner.Type.ToString() != book.Type.ToString() "+ this.owner.Type.ToString());}
            if (this.borrowed.Count() > 3){throw new InvalidOperationException("You have already ordered 3 books <MAX 3 Books>"); }
            if (book.Status == Book.BookStatus.OutOfTheLibrary) { throw new InvalidOperationException("book.BookStatus is Out Of The Library "); } 
            if (book.Status == Book.BookStatus.OutOfTheLibrary_AndOrder) { throw new InvalidOperationException("book.BookStatus is Out Of The Library And Order"); }
            //if (invited.Contains(book) && book.Status == Book.BookStatus.OutOfTheLibrary_AndOrder || book.Status == Book.BookStatus.InTheLibrary){invited.Remove(book);}
            if (invited.Contains(book)) { invited.Remove(book); } // change the book status
            invited.Add(book);
            book.Status = Book.BookStatus.Ordered;
            return true;
        }
        public bool ReturnBook(Book bookToR)
        {
            // Validation #1 - Check if the book was indeed taken
            if (!borrowed.Contains(bookToR)){throw new InvalidOperationException("Book cannot be returned since it was not taken in this libabry account");}
            borrowed.Remove(bookToR);
            bookToR.Status = Book.BookStatus.InTheLibrary;
            return true;
        }
        public bool OrderBook_FromLibrary(Book book)
        {
            //OutOfTheLibrary_AndOrder
            if ((book.Status == Book.BookStatus.OutOfTheLibrary_AndOrder))  { throw new InvalidOperationException("book is Out Of The Library And Order"); }
            //book is Ordered by someone else
            if (book.Status == Book.BookStatus.Ordered && !invited.Contains(book)){ throw new InvalidOperationException("book is Ordered by someone else"); }
            //the Book not Match to to Reader
            if (this.owner.Type == Reader.TypeReader.Adult && book.Type == Book.BookType.Children ||
                this.owner.Type == Reader.TypeReader.Children && book.Type == Book.BookType.Adult) { throw new InvalidOperationException("the Book not Match to Reader"); }
            if (invited.Count() >= 3) { throw new InvalidOperationException("You have allready 3 books"); }
            // debts <= 0
            if (this.debts > 0) { throw new InvalidOperationException("debts > 0"); }
            // Order Book
            if (book.Status == Book.BookStatus.InTheLibrary) {book.Status = Book.BookStatus.Ordered;}
            if (book.Status == Book.BookStatus.Ordered){book.Status = Book.BookStatus.OutOfTheLibrary_AndOrder;}
            borrowed.Add(book);
            return true;
        }
        public bool Cancel_invited_Book_From_Library(Book book) {
            if (!invited.Contains(book)) { throw new InvalidOperationException("You dont Have invited for this book "); }
            book.Status = Book.BookStatus.InTheLibrary;
            invited.Remove(book);
            return true;
        }
        public bool Cancel_borrowed_Book_From_Library(Book book)
        {
            if (!borrowed.Contains(book)) { throw new InvalidOperationException("You dont Have invited for this book "); }
            book.Status = Book.BookStatus.InTheLibrary;
            borrowed.Remove(book);
            return true;
        }
    }
}
