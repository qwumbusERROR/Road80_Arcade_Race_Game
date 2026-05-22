using System;
public abstract class ObservableModel
{
    public event Action<string> PropertyChanged;

    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(propertyName);
    }
}
