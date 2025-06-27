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

namespace WpfApp2{
  public partial class AddBookWindow : Window{
    public string InputValue { get; private set; }
    public AddBookWindow(){
      InitializeComponent();
    }
    private void SaveButton_Click(object sender, RoutedEventArgs e){
      SqlConnection connection; 

      string connectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;";

      connection = new SqlConnection(connectionString);

      connection.Open();
      SqlCommand command = new SqlCommand(String.Format("UPDATE book SET book_title = N'{0}',publication_year = '{1}',author_ID = '{2}',genre_ID='{3}' WHERE books_id='{4}'",TitleTextBox.Text,YearPublishedTextBox.Text,AuthorIDTextBox.Text,GenreIDTextBox.Text,IDTextBox.Text), connection);
      command.ExecuteNonQuery();

      connection.Close();

      this.DialogResult = true;
    }
  }
}
