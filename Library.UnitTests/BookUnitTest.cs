using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.UnitTests
{
    [TestClass]
    public class BookUnitTest
    {
        private TestContext context;
        public TestContext TestContext { get { return context; } set { context = value; } }


        [TestMethod]
        [TestCategory("UnitTest_OrderBook")]
        [DataSource("System.Data.Odbc",
           @"Driver={Microsoft Excel Driver (*.xls)};dbq=C:\Users\User\source\repos\DATA\Data.xls;defaultdir=C:\Users\User\source\repos\DATA;driverid=790;fil=excel 8.0;filedsn=C:\Users\User\source\repos\DATA\NewLibraryData.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=1;safetransactions=0;threads=3;uid=admin;usercommitsync=Yes"
           , "Sheet1$"
           , DataAccessMethod.Sequential)]
        public void OrderBook_CheckIfCanInvitedBookByWorngType_returnInvalidOperationException() // הפונקציה בודקת האם קורא1 יכול להזמין ספר שקורא2 כבר הזמין
        {
            //arr from data
            Book.BookStatus bookStatus;
            Book.BookType bookType;
            Reader.TypeReader typeReader;
            bool exp= true;
            string exp_= Convert.ToString(context.DataRow["exp"].ToString());
            // data sort for BookStatus  () =>
            if (Convert.ToString(context.DataRow["BookStatus"].ToString()) == "InTheLibrary") { bookStatus = Book.BookStatus.InTheLibrary; }
            else if (Convert.ToString(context.DataRow["BookStatus"].ToString()) == "OutOfTheLibrary") { bookStatus = Book.BookStatus.OutOfTheLibrary; }
            else if (Convert.ToString(context.DataRow["BookStatus"].ToString()) == "OutOfTheLibrary_AndOrder") { bookStatus = Book.BookStatus.OutOfTheLibrary_AndOrder; }
            else { bookStatus = Book.BookStatus.Ordered; }

            // data sort for BookType    () =>
            if (Convert.ToString(context.DataRow["BookType"].ToString()) == "Adult") { bookType = Book.BookType.Adult; }
            else { bookType = Book.BookType.Children; }
            // data sort for TypeReader  () =>
            if (Convert.ToString(context.DataRow["TypeReader"].ToString()) == "Adult") { typeReader = Reader.TypeReader.Adult; }
            else { typeReader = Reader.TypeReader.Children; }
            //arr
            Book harry_potter = new Book("harry potter", bookType, bookStatus);     // Book
            Reader reader_1 = new Reader("ben", "noioff", typeReader);              // Reader 1 for test 
            LibraryAccount libraryAccount1 = new LibraryAccount(reader_1);          // Library Account Of Reader 1 
            //act & asr
            if (exp_.Equals("TRUE"))
            {
                bool act = libraryAccount1.invited_Book_From_Library(harry_potter);
                Assert.AreEqual( exp , act );
            }
            else if(exp_.Equals("FALSE")){
                Assert.ThrowsException<System.InvalidOperationException>(() => libraryAccount1.OrderBook_FromLibrary(harry_potter));// OrderBook a Book by reader number 2 => InvalidOperationException
            }
        }

        [TestMethod]
        [DataRow(Reader.TypeReader.Children, Book.BookStatus.OutOfTheLibrary, Book.BookType.Children, DisplayName = "1")]
        public void LoanBook_OutOfTheLibaryBook_returnfalse(Reader.TypeReader typeReader, Book.BookStatus status, Book.BookType bookType)
        {
            //arr
            Book harry_potter = new Book("harry potter", bookType, status); // Book
            Reader reader_1 = new Reader("ben", "noioff", typeReader);  // Reader 1 for test 
            LibraryAccount libraryAccount1 = new LibraryAccount(reader_1);          // Library Account Of Reader 1 
            //act & asr
            Assert.ThrowsException<System.InvalidOperationException>(() => libraryAccount1.invited_Book_From_Library(harry_potter));
        }


        [TestMethod]
        [TestCategory("UnitTest_OrderBook")]
        [DataRow(Reader.TypeReader.Children, Book.BookStatus.InTheLibrary, Book.BookType.Children, DisplayName = "Check if Someone Else Already Invited")]
        public void OrderBook_ifSomeoneElseAlreadyInvitedThisBook_returnException(Reader.TypeReader typeReader, Book.BookStatus status, Book.BookType bookType)
        {
            //arr
            Book harry_potter = new Book("harry potter", bookType, status); // Book
            Reader reader_1 = new Reader("ben", "noioff", typeReader);  // Reader 1 for test 
            Reader reader_2 = new Reader("david", "as", typeReader);   // Reader 2 for test 
            LibraryAccount libraryAccount1 = new LibraryAccount(reader_1);          // Library Account Of Reader 1 
            LibraryAccount libraryAccount2 = new LibraryAccount(reader_2);          // Library Account Of Reader 2 
            //act & asr
            libraryAccount1.invited_Book_From_Library(harry_potter); // invited a Book by reader number 1 =>
            Assert.ThrowsException<System.InvalidOperationException>(() => libraryAccount2.OrderBook_FromLibrary(harry_potter));// OrderBook a Book by reader number 2 => InvalidOperationException
        }

        [TestMethod]
        [DataRow(Reader.TypeReader.Children, Book.BookStatus.InTheLibrary, Book.BookType.Children, DisplayName = "Check if Someone Else Already Invited")]
        public void CancelInvited_ifSomeoneElseAlreadyInvitedThisBook_returnException(Reader.TypeReader typeReader, Book.BookStatus status, Book.BookType bookType)
        {
            //arr
            Book harry_potter = new Book("harry potter", bookType, status); // Book
            Reader reader_1 = new Reader("ben", "noioff", typeReader);  // Reader 1 for test 
            LibraryAccount libraryAccount1 = new LibraryAccount(reader_1);          // Library Account Of Reader 1 
            // not invited_Book_From_Library from this Library Account (like that => "libraryAccount1.invited_Book_From_Library(harry_potter);" ).
            // so the call libraryAccount1.Cancel_invited_Book_From_Library(harry_potter) throw new InvalidOperationException.
            Assert.ThrowsException<System.InvalidOperationException>(() => libraryAccount1.Cancel_invited_Book_From_Library(harry_potter));// OrderBook a Book by reader number 2 => InvalidOperationException
        }



        [TestMethod]
        [TestCategory("UnitTest_LoanBook")]
        [DataRow(Reader.TypeReader.Adult, Book.BookStatus.OutOfTheLibrary, Book.BookType.Children,false, DisplayName = "TypeReader.Adult -> BookType.Children")]
        [DataRow(Reader.TypeReader.Adult, Book.BookStatus.InTheLibrary, Book.BookType.Adult, true, DisplayName = "TypeReader.Children -> BookType.Adult ")]
        [DataRow(Reader.TypeReader.Adult, Book.BookStatus.OutOfTheLibrary, Book.BookType.Adult, false, DisplayName = "TypeReader.Children -> BookType.Adult ")]
        [DataRow(Reader.TypeReader.Children, Book.BookStatus.OutOfTheLibrary, Book.BookType.Adult, false, DisplayName = "TypeReader.Children -> BookType.Adult ")]
        public void LoanBook_CheckIfCanInvitedBookByWorngType_returnInvalidOperationException_CheckIfCanInvitedBookByWorngType_returnInvalidOperationException(Reader.TypeReader typeReader, Book.BookStatus status, Book.BookType bookType,bool exp)// הפונקצתיה בודקת האם ילד יכול להזמין ספר של מבוגר ולהפך
        {
            //arr
            Reader Test_reader = new Reader("ben", "noioff", typeReader);
            Book Test_Book = new Book("c#", bookType, status);
            LibraryAccount libraryAccount = new LibraryAccount(Test_reader);
            //act
            //act & asr
            if (exp) {  // check if function return exp OR bool result
                bool act = libraryAccount.invited_Book_From_Library(Test_Book);
                Assert.AreEqual(act, exp);
            }
            else
                Assert.ThrowsException<System.InvalidOperationException>(() => libraryAccount.invited_Book_From_Library(Test_Book));        // OrderBook a Book by reader number 2 => InvalidOperationException

        }


    }

}