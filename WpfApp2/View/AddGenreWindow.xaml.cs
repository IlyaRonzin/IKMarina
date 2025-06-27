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
  public partial class AddGenreWindow : Window{
    public AddGenreWindow(){
      InitializeComponent();
    }
    private void SaveButton_Click(object sender, RoutedEventArgs e){
      SqlConnection connection;

      string connectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;";

      connection = new SqlConnection(connectionString);

      connection.Open();
      SqlCommand command = new SqlCommand(String.Format("UPDATE genre SET genre_name = N'{0}', description = N'{1}' WHERE genre_ID = '{2}'", GenreTextBox.Text,DescriptionTextBox.Text,GenreIDTextBox.Text), connection);
      command.ExecuteNonQuery();

      connection.Close();

      this.DialogResult = true; 
    }
  }
}
