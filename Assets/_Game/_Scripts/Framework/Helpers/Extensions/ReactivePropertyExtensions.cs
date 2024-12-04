using R3;

namespace _Game._Scripts.Framework.Helpers.Extensions
{
    public static class ReactivePropertyExtensions
    {
        public static void NotifyIfDataIsClass<T>(this ReactiveProperty<T> property)
        {
            if (typeof(T).IsClass) property.ForceNotify();
        }
    }
}
