using _05_ModelBindingExample.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _05_ModelBindingExample.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new();
            // FirstName and LastName
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }

            bindingContext.Result = ModelBindingResult.Success(person);
        }
    }
}
