using System;

public class ReactiveProperty<TProperty> : IDisposable
{
    private event Action<TProperty> _onChanged;

    private TProperty _value;
    public TProperty Value
    {
        get => _value;
        set
        {
            if (Equals(_value, value)) return;

            _value = value;
            _onChanged?.Invoke(_value);
        }
    }

    public void Subscribe(Action<TProperty> onChanged)
    {
        _onChanged += onChanged;
    }

    public void Unsubscribe(Action<TProperty> onChanged)
    {
        _onChanged -= onChanged;
    }

    public void Dispose()
    {
        _onChanged = null;
    }
}
