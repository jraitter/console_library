using System;
using System.Collections.Generic;
using console_library.Models;

namespace console_library
{
  class Program
  {
    static void Main(string[] args)
    {
      bool inLibrary = true;
      Enum activeMenu = Menus.CheckoutBook;
      Library nampa = new Library("123 Maint St.", "Nampa");
      Book wtse = new Book("Where The Sidewalk Ends", "Shel Silverstein");
      nampa.AddBook(wtse); //single book method

      Book sw4 = new Book("Star Wars: A New Hope", "Ryder Windham");
      Book sw5 = new Book("Star Wars: Empire Strikes Back", "Ryder Windham");
      Book sw6 = new Book("Star Wars: Return of the Jedi", "Ryder Windham");

      List<Book> swSagabooks = new List<Book>()
      {
        sw4,
        sw5,
        sw6
      };
      nampa.AddBook(swSagabooks);//using method overriding

      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Green;

      Console.WriteLine("\n\nHello libraty student\n");
      Console.WriteLine("Welcome to the Nampa Library\n");

      //start the while loop
      while (inLibrary)
      {
        switch (activeMenu)
        {
          case Menus.CheckoutBook:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Available Books: \n");
            nampa.PrintAvailableBooks();
            Console.WriteLine("Select a book number to checkout (q)uit, or (r)eturn a book");
            break;
          case Menus.ReturnBook:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Checked out books: \n");
            nampa.PrintCheckedOutBooks();
            Console.WriteLine("Select a book number to return, (q)uit, or (a)vailable books");
            break;
        }
        string selection = Console.ReadLine();
        Console.Clear();
        if (selection.Trim().ToLower() == "q" || selection.Trim().ToLower() == "quit")
        {
          inLibrary = false;
          Console.WriteLine("Thank you for exploring the Nampa Library");
          Console.ForegroundColor = ConsoleColor.White;
          break;
        }
        else if (selection.Trim().ToLower() == "r" || selection.Trim().ToLower() == "return")
        {
          activeMenu = Menus.ReturnBook;
        }
        else if (selection.Trim().ToLower() == "a" || selection.Trim().ToLower() == "available")
        {
          activeMenu = Menus.CheckoutBook;
        }
        else
        {
          if (activeMenu.Equals(Menus.CheckoutBook))
          {
            nampa.Checkout(selection);
          }
          else
          {
            nampa.ReturnBook(selection);
          }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.ResetColor();
      }//end while loop

    }//end of Main

    public enum Menus
    {
      CheckoutBook,
      ReturnBook
    }//end of enum Menus

  }//end of class Program
}//end of namespace
