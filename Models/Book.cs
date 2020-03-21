namespace console_library.Models
{
  public class Book
  {
    public string Title { get; set; }
    public string Author { get; set; }
    public bool Available { get; set; }




    //constructor
    public Book(string title, string author)
    {
      Title = title;
      Author = author;
      Available = true;
    }
  }//end of class Book
}//end of namespace