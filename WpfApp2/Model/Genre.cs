using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
  /// <summary>
  /// Представляет сущность жанра с полями для идентификатора, названия и описания
  /// </summary>
  public class Genre
  {
    private int _id;
    private string _name;
    private string _description;

    /// <summary>
    /// Получает или задает идентификатор жанра
    /// </summary>
    public int ID
    {
      get => _id;
      set => _id = value;
    }

    /// <summary>
    /// Получает или задает название жанра
    /// </summary>
    public string Name
    {
      get => _name;
      set => _name = value;
    }

    /// <summary>
    /// Получает или задает описание жанра
    /// </summary>
    public string Description
    {
      get => _description;
      set => _description = value;
    }
  }
}