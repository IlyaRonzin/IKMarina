using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using WpfApp2.Model;

namespace WpfApp2{
  /// <summary>
  /// Обеспечивает операции с базой данных для управления книгами, авторами и жанрами
  /// </summary>
  public static class Database{
    public static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;";

    /// <summary>
    /// Добавляет нового автора в базу данных с значениями по умолчанию
    /// </summary>
    /// <returns>Идентификатор созданного автора</returns>
    public static int AddNewAuthor(){
      using (SqlConnection connection = new SqlConnection(Database.connectionString)){
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT MAX(author_ID) FROM author", connection);
        int maxId = int.Parse(command.ExecuteScalar().ToString()) + 1;
        command = new SqlCommand($"INSERT INTO author (author_ID, author_name, biography) VALUES ('{maxId}', 'ERROR', 'ERROR')", connection);
        command.ExecuteNonQuery();
        return maxId;
      }
    }

    /// <summary>
    /// Добавляет новый жанр в базу данных с значениями по умолчанию
    /// </summary>
    /// <returns>Идентификатор созданного жанра</returns>
    public static int AddNewGenre(){
      using (SqlConnection connection = new SqlConnection(connectionString)){
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT MAX(genre_ID) FROM genre", connection);
        int maxId = int.Parse(command.ExecuteScalar().ToString()) + 1;
        command = new SqlCommand($"INSERT INTO genre (genre_ID, genre_name, description) VALUES ('{maxId}', 'ERROR', 'ERROR')", connection);
        command.ExecuteNonQuery();
        return maxId;
      }
    }

    /// <summary>
    /// Добавляет новую книгу в базу данных с значениями по умолчанию
    /// </summary>
    /// <returns>Идентификатор созданной книги</returns>
    public static int AddNewBook(){
      using (SqlConnection connection = new SqlConnection(Database.connectionString)){
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT MAX(books_id) FROM book", connection);
        int maxId = int.Parse(command.ExecuteScalar().ToString()) + 1;
        command = new SqlCommand($"INSERT INTO book (books_id, book_title, publication_year, author_ID, genre_ID) VALUES ('{maxId}', '0', '0', '1', '1')", connection);
        command.ExecuteNonQuery();
        return maxId;
      }
    }

    /// <summary>
    /// Удаляет строку из указанной таблицы по заданному идентификатору
    /// </summary>
    /// <param name="tableName">Имя таблицы для удаления</param>
    /// <param name="idColumnName">Имя столбца идентификатора</param>
    /// <param name="id">Идентификатор удаляемой строки</param>
    public static void DeleteRow(string tableName, string idColumnName, object id){
      using (SqlConnection connection = new SqlConnection(connectionString)){
        connection.Open();
        SqlCommand command = new SqlCommand($"DELETE FROM {tableName} WHERE {idColumnName}='{id}'", connection);
        command.ExecuteNonQuery();
      }
    }

    /// <summary>
    /// Обновляет таблицы данных последними данными из базы
    /// </summary>
    /// <param name="booksDataGrid">Таблица для отображения книг</param>
    /// <param name="authorsDataGrid">Таблица для отображения авторов</param>
    /// <param name="genresDataGrid">Таблица для отображения жанров</param>
    public static void UpdateGrid(DataGrid booksDataGrid, DataGrid authorsDataGrid, DataGrid genresDataGrid){
      using (SqlConnection connection = new SqlConnection(connectionString)){
        connection.Open();
        SqlDataReader reader = null;

        SqlCommand command = new SqlCommand("SELECT * FROM [book]", connection);
        reader = command.ExecuteReader();
        booksDataGrid.Items.Clear();
        while (reader.Read()){
          booksDataGrid.Items.Add(new Book
          {
            ID = (int)reader["books_id"],
            Title = (string)reader["book_title"],
            YearPublished = (int)reader["publication_year"],
            AuthorID = (int)reader["author_ID"],
            GenreID = (int)reader["genre_ID"]
          });
        }
        reader.Close();

        command = new SqlCommand("SELECT * FROM [genre]", connection);
        reader = command.ExecuteReader();
        genresDataGrid.Items.Clear();
        while (reader.Read()){
          genresDataGrid.Items.Add(new Genre
          {
            ID = (int)reader["genre_ID"],
            Name = (string)reader["genre_name"],
            Description = (string)reader["description"]
          });
        }
        reader.Close();

        command = new SqlCommand("SELECT * FROM [author]", connection);
        reader = command.ExecuteReader();
        authorsDataGrid.Items.Clear();
        while (reader.Read()){
          authorsDataGrid.Items.Add(new Author
          {
            ID = (int)reader["author_ID"],
            FullName = (string)reader["author_name"],
            Biography = (string)reader["biography"]
          });
        }
        reader.Close();
      }
    }
  }
}