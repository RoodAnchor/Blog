using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Exceptions
{
    public class TagNotFoundException : Exception
    {
        public TagNotFoundException() :base("Тэг не найден в БД") { }
    }
}
