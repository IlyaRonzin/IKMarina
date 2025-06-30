using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model{
  /// <summary>
  /// Представляет сущность книги с полями для идентификатора, названия, года публикации, идентификатора автора и жанра
  /// </summary>
  public class Book{
    private int _id;
    private string _title;
    private int _yearPublished;
    private int _authorID;
    private int _genreID;

    /// <summary>
    /// Получает или задает идентификатор книги
    /// </summary>
    public int ID{
      get => _id;
      set => _id = value;
    }

    /// <summary>
    /// Получает или задает название книги
    /// </summary>
    public string Title{
      get => _title;
      set => _title = value;
    }

    /// <summary>
    /// Получает или задает год публикации книги
    /// </summary>
    public int YearPublished{
      get => _yearPublished;
      set => _yearPublished = value;
    }

    /// <summary>
    /// Получает или задает идентификатор автора книги
    /// </summary>
    public int AuthorID{
      get => _authorID;
      set => _authorID = value;
    }

    /// <summary>
    /// Получает или задает идентификатор жанра книги
    /// </summary>
    public int GenreID{
      get => _genreID;
      set => _genreID = value;
    }
  }
}