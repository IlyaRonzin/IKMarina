using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
  /// <summary>
  /// Логика взаимодействия для AddBookWindow.xaml
  /// </summary>
  public partial class AddBookWindow : Window
  {
    /// <summary>
    /// Получает входное значение для книги
    /// </summary>
    public string InputValue { get; private set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса AddBookWindow
    /// </summary>
    public AddBookWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Обрабатывает событие нажатия кнопки "Сохранить" для обновления данных книги в базе
    /// </summary>
    /// <param name="sender">Источник события</param>
    /// <param name="e">Данные события</param>
    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        using (SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;"))
        {
          connection.Open();
          SqlCommand command = new SqlCommand(
            "UPDATE book SET book_title = @title, publication_year = @year, author_ID = @authorID, genre_ID = @genreID WHERE books_id = @bookID",
            connection);
          command.Parameters.AddWithValue("@title", TitleTextBox.Text);
          command.Parameters.AddWithValue("@year", int.Parse(YearPublishedTextBox.Text));
          command.Parameters.AddWithValue("@authorID", int.Parse(AuthorIDTextBox.Text));
          command.Parameters.AddWithValue("@genreID", int.Parse(GenreIDTextBox.Text));
          command.Parameters.AddWithValue("@bookID", int.Parse(IDTextBox.Text));
          command.ExecuteNonQuery();
        }
        this.DialogResult = true;
      }
      catch (SqlException ex)
      {
        MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      catch (FormatException ex)
      {
        MessageBox.Show($"Ошибка ввода: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}