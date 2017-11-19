using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Business
{
    public class MsgProvider:IProvider
    {
        public string GetMessage()
        {
            return  "Welcome to this website";
        }
    }
}
