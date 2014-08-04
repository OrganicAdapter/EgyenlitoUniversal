using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egyenlito.Implementations
{
    public class TypeService : ITypeService
    {
        public Type GetType(string type)
        {
            return Type.GetType(type);
        }
    }
}
