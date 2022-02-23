using System.Runtime.CompilerServices;

namespace CompanyWebApi.Core
{

    // I am trying to implement service injection for Lazy Loading to
    // decrease dependency on EF packages. This class is not used on the current 
    // migration, it is here for future development. 

    public static class ApiLoadingExtensions
    {
        public static TRelated Load<TRelated>(
            this Action<object, string> loader,
            object entity,
            ref TRelated navigationField,
            [CallerMemberName] string? navigationName = null) where TRelated : class
        {
            loader?.Invoke(entity, navigationName ?? throw new ArgumentNullException(nameof(navigationName), "Navigation name is required"));

            return navigationField;
        }

    }
}
