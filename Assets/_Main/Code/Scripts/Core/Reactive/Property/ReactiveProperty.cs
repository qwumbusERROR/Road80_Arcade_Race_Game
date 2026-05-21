using System;

public class ReactiveProperty<TProperty>
{
    private event Action<TProperty> OnChanged;

    private TProperty _value;
    public TProperty Value
    {
        get => _value;
        set
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }

    public void Subscribe(Action<TProperty> onChanged)
    {
        OnChanged += onChanged;
    }

    public void Unsubscribe(Action<TProperty> onChanged)
    {
        OnChanged -= onChanged;
    }
}
