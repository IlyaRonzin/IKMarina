using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using WpfApp2.Model;

namespace WpfApp2
{
  public static class Database
  {
    public static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;";
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
    public static int AddNewGenre()
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT MAX(genre_ID) FROM genre", connection);
        int maxId = int.Parse(command.ExecuteScalar().ToString()) + 1;
        command = new SqlCommand($"INSERT INTO genre (genre_ID, genre_name, description) VALUES ('{maxId}', 'ERROR', 'ERROR')", connection);
        command.ExecuteNonQuery();
        return maxId;
      }
    }

    public static int AddNewBook(){
      using (SqlConnection connection = new SqlConnection(Database.connectionString)){
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT MAX(books_id) FROM book", connection);
        int maxId = int.Parse(command.ExecuteScalar().ToString()) + 1;
        command = new SqlCommand($"INSERT INTO book (books_id, book_title, publication_year, author_ID, genre_ID) VALUES ('{maxId}', 'ERROR', 'ERROR', '1', '1')", connection);
        command.ExecuteNonQuery();
        return maxId;
      }
    }

    public static void DeleteRow(string tableName, string idColumnName, object id)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand($"DELETE FROM {tableName} WHERE {idColumnName}='{id}'", connection);
        command.ExecuteNonQuery();
      }
    }

    public static void UpdateGrid(DataGrid booksDataGrid, DataGrid authorsDataGrid, DataGrid genresDataGrid)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlDataReader reader = null;
       
        SqlCommand command = new SqlCommand("SELECT * FROM [book]", connection);
        reader = command.ExecuteReader(); 
        booksDataGrid.Items.Clear();
        while (reader.Read())
        {
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
        while (reader.Read())
        {
          genresDataGrid.Items.Add(new Genre
          {
            ID = reader["genre_ID"],
            Name = reader["genre_name"],
            Description = reader["description"]
          });
        }
        reader.Close();

        command = new SqlCommand("SELECT * FROM [author]", connection);
        reader = command.ExecuteReader();
        authorsDataGrid.Items.Clear();
        while (reader.Read())
        {
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