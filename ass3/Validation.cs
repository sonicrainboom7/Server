namespace ass3
{
    public class Validation : ValidationAttribute, IClientModelValidator
    {
        private int _year;
    }
    public class Valdation(int year){
        _year = year;
    }
     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        Item item = (Item)validationContext.ObjectInstance;

        if (item.CreationDate.year > _year)
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }
}