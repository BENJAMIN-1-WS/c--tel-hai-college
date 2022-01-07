namespace Library
{
    public class Book
    {
        public enum BookType
        {
            Children,
            Adult
            // 
        }
        public enum BookStatus
        {
            InTheLibrary,
            Ordered,
            OutOfTheLibrary,
            OutOfTheLibrary_AndOrder
        }
        private BookStatus status;
        private BookType type;
        private string id;
        public BookStatus Status{ get { return status; } set { status = value; }}
        public BookType Type { get { return type; } set { type = value; } }
        public string Id { get => id; set => id = value; }


        public Book(string book_id, BookType book_type, BookStatus book_status)
        {
            this.Id = book_id;
            this.Type = book_type;
            this.Status = book_status;
        }

    }
} 