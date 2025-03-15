using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CleanArchitecture.Persistance
{
   public static class AssemblyReferance
    {
        public static readonly Assembly Assembly = typeof(AssemblyReferance).Assembly;
    }
}
