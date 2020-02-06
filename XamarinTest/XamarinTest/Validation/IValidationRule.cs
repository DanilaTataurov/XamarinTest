namespace XamarinTest.Validation {
    public interface IValidationRule {
        bool Check(object value);
        string ValidationMessage { get; set; }
    }

    public interface IValidationRule<T> : IValidationRule {
        bool Check(T value);
    }
}
