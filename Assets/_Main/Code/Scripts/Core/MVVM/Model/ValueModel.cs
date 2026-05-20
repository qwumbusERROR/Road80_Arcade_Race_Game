using UnityEngine;

public abstract class ValueModel<T> : ObservableModel
{
    protected T _currentValue;
    protected T _maxValue;

    public ValueModel(T current, T maximum)
    {
        _currentValue = current;
        _maxValue = maximum;
    }

    public T CurrentValue
    {
        get => _currentValue;
        private set
        {
            //защита и clamped
            OnPropertyChanged();
        }
    }

    public abstract void AddValue(T amount);
    public abstract void RemoveValue(T amount);

    protected abstract void Clamped();
}
