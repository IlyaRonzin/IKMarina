using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.Model{
  public class Author{
    private int _id;
    private string _fullName;
    private string _biography;

    public int ID{
      get => _id;
      set => _id = value;
    }

    public string FullName{
      get => _fullName;
      set => _fullName = value;
    }

    public string Biography{
      get => _biography;
      set => _biography = value;
    }
  }
}
