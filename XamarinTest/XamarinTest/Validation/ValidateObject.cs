using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;

namespace XamarinTest.Validation {
    public class ValidateObject<T> : BindableBase, IValidation {
        public bool IsValid => Validate();
        public ObservableCollection<string> Errors { get; }
        public List<IValidationRule> Validations { get; }
        private T _value;

        public T Value {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        private bool Validate() {
            Errors.Clear();
            var errors = Validations
                .Where(property =>
                    !property.Check(Value))
                .Select(property =>
                    property.ValidationMessage);
            foreach (var error in errors) {
                Errors.Add(error);
            }
            return !Errors.Any();
        }
    }
}
