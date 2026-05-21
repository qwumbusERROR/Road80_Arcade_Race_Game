using System;
using System.Runtime.CompilerServices;

public abstract class ObservableModel<TValue>
{
    public readonly ReactiveProperty<TValue> Value = new();
    
    public ObservableModel(TValue value) 
    {
        Value.Value = value;
    }
}
