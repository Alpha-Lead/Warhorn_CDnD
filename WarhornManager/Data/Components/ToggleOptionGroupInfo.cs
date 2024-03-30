using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WarhornManager.Data.Components
{
    public class ToggleOptionGroupInfo : INotifyPropertyChanged
    {
        public required string[] Options;
        private string? _selectedOption;
        public string? SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                if (value == _selectedOption) return;
                if (!Options.Contains(value)) Options.Append(value);
                _selectedOption = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName="")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string GetActive(string option)
        {
            return option == SelectedOption ? "active" : "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
