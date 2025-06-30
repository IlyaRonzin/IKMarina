using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model{
  /// <summary>
  /// Представляет сущность автора с полями для идентификатора, имени и биографии
  /// </summary>
  public class Author{
    private int _id;
    private string _fullName;
    private string _biography;

    /// <summary>
    /// Получает или задает идентификатор автора
    /// </summary>
    public int ID{
      get => _id;
      set => _id = value;
    }

    /// <summary>
    /// Получает или задает полное имя автора
    /// </summary>
    public string FullName{
      get => _fullName;
      set => _fullName = value;
    }

    /// <summary>
    /// Получает или задает биографию автора
    /// </summary>
    public string Biography{
      get => _biography;
      set => _biography = value;
    }
  }
}