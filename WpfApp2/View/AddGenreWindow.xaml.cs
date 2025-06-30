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
  /// Логика взаимодействия для AddGenreWindow.xaml
  /// </summary>
  public partial class AddGenreWindow : Window
  {
    /// <summary>
    /// Инициализирует новый экземпляр класса AddGenreWindow
    /// </summary>
    public AddGenreWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Обрабатывает событие нажатия кнопки "Сохранить" для обновления данных жанра в базе
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
            "UPDATE genre SET genre_name = @genreName, description = @description WHERE genre_ID = @genreID",
            connection);
          command.Parameters.AddWithValue("@genreName", GenreTextBox.Text);
          command.Parameters.AddWithValue("@description", DescriptionTextBox.Text);
          command.Parameters.AddWithValue("@genreID", int.Parse(GenreIDTextBox.Text));
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