using System;
using NUnit.Framework;
namespace Library.UnitTests
{
    [TestFixture]
    public class BookNUnitTest
    {


        [Test]
        [TestCase(Reader.TypeReader.Children, Book.BookStatus.OutOfTheLibrary, Book.BookType.Adult, false, TestName = " typeReader.Children -> BookType.Adult")]
        [TestCase(Reader.TypeReader.Adult, Book.BookStatus.InTheLibrary, Book.BookType.Adult, true, TestName = " typeReader.Adult != BookType.Adult")]
        public void LoanBook_CheckIfBookOutOfTheLibary_returnfalse(Reader.TypeReader typeReader, Book.BookStatus status, Book.BookType bookType, bool exp)
        {
            //arr
            Reader Test_reader = new Reader("ben", "noioff", typeReader);
            Book Test_Book = new Book("c#", bookType, status);
            LibraryAccount libraryAccount = new LibraryAccount(Test_reader);
            //act
            //act & asr
            if (exp)
            {  // check if function return exp OR bool result
                bool act = libraryAccount.invited_Book_From_Library(Test_Book);
                Assert.AreEqual(act, exp);
            }
            else
                Assert.Throws<System.InvalidOperationException>(() => libraryAccount.invited_Book_From_Library(Test_Book));        // OrderBook a Book by reader number 2 => InvalidOperationException
        }

        [Test]
        [Timeout(3)]
        [TestCase(Reader.TypeReader.Children, Book.BookStatus.InTheLibrary, Book.BookType.Children, TestName = "Check if Someone Else Already Invited")]
        public void OrderBook_CheckifSomeoneElseAlreadyInvitedThisBook_returnException(Reader.TypeReader typeReader, Book.BookStatus status, Book.BookType bookType)
        {
            //arr
            Book harry_potter = new Book("harry potter", bookType, status); // Book
            Reader reader_1 = new Reader("ben", "noioff", typeReader);  // Reader 1 for test 
            Reader reader_2 = new Reader("david", "as", typeReader);   // Reader 2 for test 
            LibraryAccount libraryAccount1 = new LibraryAccount(reader_1);          // Library Account Of Reader 1 
            LibraryAccount libraryAccount2 = new LibraryAccount(reader_2);          // Library Account Of Reader 2 
            //act & asr
            libraryAccount1.invited_Book_From_Library(harry_potter); // invited a Book by reader number 1 =>
            Assert.Throws<System.InvalidOperationException>(() => libraryAccount2.OrderBook_FromLibrary(harry_potter));// OrderBook a Book by reader number 2 => InvalidOperationException
        }


        [Test]
        [TestCase(Reader.TypeReader.Children, Book.BookStatus.OutOfTheLibrary, Book.BookType.Children, TestName = "Book => Out Of LibaryBook")]
        public void LoanBook_OutOfTheLibaryBook_returnfalse(Reader.TypeReader typeReader, Book.BookStatus status, Book.BookType bookType)
        {
            //arr
            Book harry_potter = new Book("harry potter", bookType, status); // Book
            Reader reader_1 = new Reader("ben", "noioff", typeReader);  // Reader 1 for test 
            LibraryAccount libraryAccount1 = new LibraryAccount(reader_1);          // Library Account Of Reader 1 
            //act & asr
            Assert.Throws<System.InvalidOperationException>(() => libraryAccount1.invited_Book_From_Library(harry_potter));
        }
    }


}
