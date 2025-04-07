using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Architecture.Validations
{
    public class ManagerValidator
    {
        public static bool ValueIsLessThan<T>(T obj, decimal value, decimal target, Action<T> action) where T : class
        {
            if (value < target)
            {
                action?.Invoke(obj);
                return true;
            }
            return false;
        }
    }
}
