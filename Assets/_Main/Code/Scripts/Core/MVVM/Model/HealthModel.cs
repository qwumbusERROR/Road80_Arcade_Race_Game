using System;

public sealed class HealthModel : ObservableModel
{
    private int _currentHealth = 0;
    private int _maxHealth = 0;
    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            int clampedValue = Math.Clamp(value, 0, MaxHealth);

            if (_currentHealth == clampedValue)
                return;

            _currentHealth = clampedValue;

            OnPropertyChanged();
        }
    }
    public int MaxHealth
    {
        get => _maxHealth;
        private set
        {
            if (_maxHealth == value) return;
            _maxHealth = value;

            OnPropertyChanged();
        }
    }

    public HealthModel(int maxHealth, int initHealth)
    {
        _maxHealth = Math.Max(1, maxHealth);

        if (initHealth < 0)
            _currentHealth = _maxHealth;                    
        else
            _currentHealth = Math.Clamp(initHealth, 0, _maxHealth);
    }

    public void SetHealth(int amount)
    {
        CurrentHealth = amount;
    }

    public void AddHealth(int amount)
    {
        if (amount <= 0) return;

        CurrentHealth = _currentHealth + amount;
    }

    public void RemoveHealth(int amount)
    {
        if (amount <= 0) return;

        CurrentHealth = _currentHealth - amount;
    }
}
