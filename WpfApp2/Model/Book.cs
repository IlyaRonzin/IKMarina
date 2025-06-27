using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model{
  public class Book{
    private int _id;
    private string _title;
    private int _yearPublished;
    private int _authorID;
    private int _genreID;

    public int ID{
      get => _id;
      set => _id = value;
    }

    public string Title{
      get => _title;
      set => _title = value;
    }

    public int YearPublished{
      get => _yearPublished;
      set => _yearPublished = value;
    }

    public int AuthorID{
      get => _authorID;
      set => _authorID = value;
    }

    public int GenreID{
      get => _genreID;
      set => _genreID = value;
    }
  }
}
