using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model{
  public class Genre{
    private object _id;
    private object _name;
    private object _description;

    public object ID{
      get => _id;
      set => _id = value;
    }

    public object Name{
      get => _name;
      set => _name = value;
    }

    public object Description{
      get => _description;
      set => _description = value;
    }
  }
}
