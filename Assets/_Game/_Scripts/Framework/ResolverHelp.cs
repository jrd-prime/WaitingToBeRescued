﻿using UnityEngine.Assertions;
using VContainer;

namespace _Game._Scripts.Framework
{
    // TODO inject container
    public static class ResolverHelp
    {
        public static T ResolveAndCheck<T>(IObjectResolver container) where T : class
        {
            var obj = container.Resolve<T>();
            Assert.IsNotNull(obj, $"{typeof(T).Name} is null.");
            return obj;
        }
    }
}
