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
  public partial class AddAuthorWindow : Window{
    public AddAuthorWindow(){
      InitializeComponent();
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e){
      SqlConnection connection; 

      string connectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;";

      connection = new SqlConnection(connectionString);

      connection.Open();
      SqlCommand command = new SqlCommand(String.Format("UPDATE author SET author_name = N'{0}', biography = N'{1}' WHERE author_ID = '{2}'", AuthorNameTextBox.Text,BiographyTextBox.Text, AuthorIDTextBox.Text), connection);
      command.ExecuteNonQuery();

      connection.Close();

      this.DialogResult = true;
    }
  }
}
