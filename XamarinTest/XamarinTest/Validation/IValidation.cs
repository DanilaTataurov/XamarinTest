using System.Collections.ObjectModel;

namespace XamarinTest.Validation {
    public interface IValidation {
        bool IsValid { get; }
        ObservableCollection<string> Errors { get; }
    }
}
