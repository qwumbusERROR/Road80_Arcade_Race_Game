public sealed class HealthViewModel : ViewModel
{
    public readonly ReactiveProperty<int> CurrentHealth = new();
    public readonly ReactiveProperty<int> MaxHealth = new();

    public readonly ReactiveProperty<float> Normalized = new();

    private readonly HealthModel _currentModel;
    public HealthViewModel(HealthModel model) : base(model)
    {
        _currentModel = model;
    }

    public override void Initialize()
    {
        _currentModel.PropertyChanged += OnHealthChanged;

        UpdatedProperty();
    }

    public override void Dispose()
    {
        _currentModel.PropertyChanged -= OnHealthChanged;

        DisposesProperty();
    }

    private void OnHealthChanged(string propertyName)
    {
        UpdatedProperty();
    }
    private void UpdatedProperty()
    {
        CurrentHealth.Value = _currentModel.CurrentHealth;
        MaxHealth.Value = _currentModel.MaxHealth;
        Normalized.Value = _currentModel.MaxHealth > 0 ? (float)_currentModel.CurrentHealth / _currentModel.MaxHealth : 0f;
    }

    private void DisposesProperty()
    { 
        CurrentHealth.Dispose();
        MaxHealth.Dispose();
        Normalized.Dispose();
    }

    public void TakeDamage(int amount)
    {
        _currentModel.RemoveHealth(amount);
    }

    public void Heal(int amount)
    {
        _currentModel.AddHealth(amount);
    }

    public void SetHealth(int amount)
    {
        _currentModel.SetHealth(amount);
    }
}
