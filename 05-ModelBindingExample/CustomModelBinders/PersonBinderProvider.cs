using _05_ModelBindingExample.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace _05_ModelBindingExample.CustomModelBinders
{
    public class PersonBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
            {
                // If model class is of person type, return a new binder type provider
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            }

            // If the model class is of another type, it just uses the standard model binders
            return null;
        }
    }
}
