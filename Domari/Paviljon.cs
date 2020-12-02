using System;
using System.Collections.Generic;
using System.Text;

namespace Domari
{
    public interface IPodaci
    {
        string DajImePaviljona();
    }
    public class Paviljon : IPodaci
    {
        public string DajImePaviljona()
        {
            throw new NotImplementedException();
        }
    }
}
