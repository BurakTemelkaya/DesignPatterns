using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento//Bir nesne değişikliği uğradıktan sonra ,
                 //arzu edildiğinde değişikliği uğramadan eski haline dönüşü sağlanır.
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = 1,
                Title = "Sefiller",
                Author = "Victor Hugo"
            };

            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = 54321;
            book.Title = "VICTOR HUGO";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadLine();
        }
    }
    class Book
    {
        private string _title;
        private string _author;
        private int _isbn;
        DateTime _lastEdited;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetLastEdited();
            }
        }


        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }


        public int Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }
        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("{0} , {1} , {2} , edited {3} ", Isbn, Title, Author, _lastEdited);
        }

    }
    class Memento
    {
        public int Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }
        public Memento(int isbn, string title, string author, DateTime lastedited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastedited;
        }
    }
    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
