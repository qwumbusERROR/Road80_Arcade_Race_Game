using System;

public abstract class ViewModel : IDisposable
{
    protected readonly ObservableModel _model;

    public ViewModel(ObservableModel model)
    {
        _model = model ?? throw new ArgumentNullException(nameof(model));
    }

    public virtual void Initialize() { }
    public virtual void Dispose() { }
}
