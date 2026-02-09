using _05_ECommerceProblem_01.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _05_ECommerceProblem_01.CustomValidators;

public class InvoicePriceValidationAttribute : ValidationAttribute
{
    public string ProductsName { get; set; }

    public InvoicePriceValidationAttribute(string productsName)
    {
        ProductsName = productsName;
    }

    // Store the name of the other property and compare it to this property?
    // We need to get the List<Product> Products
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // I need to check whether the InvoicePrice is not null
        // But how do I get List<Product> so I can check it?

        // Traverse through the List and add them to a sum
        // Check whether this sum matches the (value)
        // If it doesn't match, return an error
        // Product has Price * Quantity

        if (value == null)
        {
            return new ValidationResult($"{validationContext.MemberName} cannot be null or empty");
        }

        Double? invoicePrice = Convert.ToDouble(value);

        PropertyInfo? productsProperty = validationContext.ObjectType.GetProperty(ProductsName);
        if (productsProperty == null)
        {
            return new ValidationResult($"{productsProperty} cannot be null or empty");
        }

        List<Product>? products = productsProperty.GetValue(validationContext.ObjectInstance) as List<Product>;
        if (products == null || products.Count == 0)
        {
            return new ValidationResult($"{ProductsName} cannot be null or empty");
        }

        double totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.Price * product.Quantity;
        }

        if (totalPrice != invoicePrice)
        {
            // Dynamically replace placeholders in the error message
            string errorMessage = string.Format(
                ErrorMessage ?? "{0} (${1}) does not match the total price of Products (${2})",
                validationContext.DisplayName, // {0} Property Name
                invoicePrice,                  // {1} Invoice Price
                totalPrice                     // {2} Total Price
            );

            return new ValidationResult(errorMessage, [validationContext.MemberName!]);
        }

        //Console.WriteLine($"Value: {value}, Products Property: {productsProperty}");

        return ValidationResult.Success;
    }
}
