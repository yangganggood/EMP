﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DotPlatform.Reflection
{
    /// <summary>
    /// 类型查找器
    /// </summary>
    public class TypeFinder : ITypeFinder
    {
        public IAssemblyFinder AssemblyFinder { get; set; }

        public TypeFinder()
        {
            AssemblyFinder = CurrentDomainAssemblyFinder.Instance;
        }

        public IEnumerable<Type> Find(Func<Type, bool> predicate)
        {
            return this.GetAllTypes().Where(predicate);
        }

        public IEnumerable<Type> FindAll()
        {
            return this.GetAllTypes();
        }

        private IEnumerable<Type> GetAllTypes()
        {
            return AssemblyFinder.GetAllAssemblies().Distinct().SelectMany(a => a.GetTypes());
        }
    }
}
