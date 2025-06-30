using System.Windows;
using System.Windows.Controls;
using WpfApp2.Model;

namespace WpfApp2
{
  public partial class MainWindow : Window{
    public MainWindow(){
      InitializeComponent();
    }

    private void WindowLoaded(object sender, RoutedEventArgs e){
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void ClickAddBook(object sender, RoutedEventArgs e){
      int newBookId = Database.AddNewBook(); 
      AddBookWindow editWindow = new AddBookWindow(); 
      editWindow.IDTextBox.Text = newBookId.ToString(); 
      editWindow.ShowDialog(); 
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid); 
    }

    private void ClickAddAuthor(object sender, RoutedEventArgs e){
      int newAuthorId = Database.AddNewAuthor();
      AddAuthorWindow editWindow = new AddAuthorWindow();
      editWindow.AuthorIDTextBox.Text = newAuthorId.ToString();
      editWindow.ShowDialog();
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void ClickAddGenre(object sender, RoutedEventArgs e){
      int newGenreId = Database.AddNewGenre();
      AddGenreWindow editWindow = new AddGenreWindow();
      editWindow.GenreIDTextBox.Text = newGenreId.ToString();
      editWindow.ShowDialog();
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void DeleteRowBook(object sender, RoutedEventArgs e){
      Database.DeleteRow("book", "books_id", ((Button)sender).CommandParameter);
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void DeleteRowAuthor(object sender, RoutedEventArgs e){
      Database.DeleteRow("author", "author_ID", ((Button)sender).CommandParameter);
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void DeleteRowGenre(object sender, RoutedEventArgs e){
      Database.DeleteRow("genre", "genre_ID", ((Button)sender).CommandParameter);
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void EditRowBook(object sender, RoutedEventArgs e){
      Button button = sender as Button;
      int bookId = (int)button.CommandParameter; 
      var book = BooksDataGrid.SelectedItem as Book; 
      AddBookWindow editWindow = new AddBookWindow(); 
      editWindow.IDTextBox.Text = book.ID.ToString();
      editWindow.TitleTextBox.Text = book.Title.ToString();
      editWindow.YearPublishedTextBox.Text = book.YearPublished.ToString();
      editWindow.AuthorIDTextBox.Text = book.AuthorID.ToString();
      editWindow.GenreIDTextBox.Text = book.GenreID.ToString();
      editWindow.ShowDialog();
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void EditRowAuthor(object sender, RoutedEventArgs e){
      var author = AuthorsDataGrid.SelectedItem as Author;
      AddAuthorWindow editWindow = new AddAuthorWindow();
      editWindow.AuthorIDTextBox.Text = author.ID.ToString();
      editWindow.AuthorNameTextBox.Text = author.FullName.ToString();
      editWindow.BiographyTextBox.Text = author.Biography.ToString();
      editWindow.ShowDialog();
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }

    private void EditRowGenre(object sender, RoutedEventArgs e){
      var genre = GenresDataGrid.SelectedItem as Genre;
      AddGenreWindow editWindow = new AddGenreWindow();
      editWindow.GenreIDTextBox.Text = genre.ID.ToString();
      editWindow.GenreTextBox.Text = genre.Name.ToString();
      editWindow.DescriptionTextBox.Text = genre.Description.ToString();
      editWindow.ShowDialog();
      Database.UpdateGrid(BooksDataGrid, AuthorsDataGrid, GenresDataGrid);
    }
  }
}