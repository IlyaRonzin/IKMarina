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
  /// Логика взаимодействия для AddAuthorWindow.xaml
  /// </summary>
  public partial class AddAuthorWindow : Window
  {
    /// <summary>
    /// Инициализирует новый экземпляр класса AddAuthorWindow
    /// </summary>
    public AddAuthorWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Обрабатывает событие нажатия кнопки "Сохранить" для обновления данных автора в базе
    /// </summary>
    /// <param name="sender">Источник события</param>
    /// <param name="e">Данные события</param>
    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
      try
      {
        using (SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;"))
        {
          connection.Open();
          SqlCommand command = new SqlCommand(
            "UPDATE author SET author_name = @authorName, biography = @biography WHERE author_ID = @authorID",
            connection);
          command.Parameters.AddWithValue("@authorName", AuthorNameTextBox.Text);
          command.Parameters.AddWithValue("@biography", BiographyTextBox.Text);
          command.Parameters.AddWithValue("@authorID", AuthorIDTextBox.Text);
          command.ExecuteNonQuery();
        }
        this.DialogResult = true;
      }
      catch (SqlException ex)
      {
        MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}