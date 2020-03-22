using System;
using System.Collections.Generic;

namespace console_library.Models
{
  class Library
  {
    //properties
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }
    public List<Book> CheckedOut { get; set; }

    List<Book> myList = null;


    //helper functions
    public void AddBook(Book newBook)
    {
      // add single book
      Books.Add(newBook);
    }
    public void AddBook(IEnumerable<Book> newBooks)
    {
      //add list of books
      Books.AddRange(newBooks);
    }

    public void PrintBooks(console_library.Program.Menus menu)
    {
      if (menu == 0)
      {
        myList = Books;
      }
      else
      {
        myList = CheckedOut;
      }
      for (int i = 0; i < myList.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {myList[i].Title} -  {myList[i].Author} \n");
      }
    }

    public void PrintAvailableBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {Books[i].Title} -  {Books[i].Author} \n");
      }
    }
    public void PrintCheckedOutBooks()
    {
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {CheckedOut[i].Title} -  {CheckedOut[i].Author} \n");
      }
    }
    public void Checkout(string selection)
    {
      Book selectBook = ValidateBook(selection, Books);
      if (selectBook == null)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{selection} is an invalid Selection");
        Console.ForegroundColor = ConsoleColor.Green;
      }
      else
      {
        selectBook.Available = false;
        CheckedOut.Add(selectBook);
        Books.Remove(selectBook);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("You have checked out: \n");
        PrintCheckedOutBooks();
        Console.ForegroundColor = ConsoleColor.Green;
      }
    }//end of Checkout method

    public void ReturnBook(string selection)
    {
      Book selectBook = ValidateBook(selection, CheckedOut);
      if (selectBook == null)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{selection} is an invalid Selection");
        Console.ForegroundColor = ConsoleColor.Green;
      }
      else
      {
        selectBook.Available = true;
        Books.Add(selectBook);
        CheckedOut.Remove(selectBook);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You have retruned the following book: \n");
        Console.WriteLine($"{selectBook.Title} -  {selectBook.Author} \n");
        Console.ForegroundColor = ConsoleColor.Cyan;
      }
    }//end of ReturnBook method
    private Book ValidateBook(string selection, List<Book> bookList)
    {
      int bookIndex = 0;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > bookList.Count)
      {
        Console.WriteLine($"selectionStr = {selection}  valid = {valid}  bookIndex = {bookIndex}");
        return null;
      }
      return bookList[bookIndex - 1];
    }


    //constructor
    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
      CheckedOut = new List<Book>();

    }//end of constructor

  }//end of class library
}//end of namespace