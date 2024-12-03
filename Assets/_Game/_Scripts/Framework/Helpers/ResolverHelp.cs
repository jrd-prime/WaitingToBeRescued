using UnityEngine.Assertions;
using VContainer;

namespace _Game._Scripts.Framework.Helpers
{
    public static class ResolverHelp
    {
        public static T ResolveAndCheck<T>(IObjectResolver resolver) where T : class
        {
            var obj = resolver.Resolve<T>();
            Assert.IsNotNull(obj, $"{typeof(T).Name} is null.");
            return obj;
        }
    }
}
