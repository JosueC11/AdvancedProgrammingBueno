using AdvancedProgramming.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Architecture.Extensions
{
    public static class ProductExtensions
    {
        public static bool HasCategoryID(this Product product) => product.CategoryID > 0;
    }
}
