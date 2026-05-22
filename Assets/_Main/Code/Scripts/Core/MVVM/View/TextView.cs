using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextView : ContentView
{
    [SerializeField] private TextMeshProUGUI _currentText;

    private ReactiveProperty<int> _sourceProperty;

    public void Bind(ReactiveProperty<int> property)
    {
        _sourceProperty = property;

        if (_currentText == null)
            _currentText = GetComponent<TextMeshProUGUI>();
    }

    public override void Initialize()
    {
        _sourceProperty.Subscribe(UpdateText);

        UpdateText(_sourceProperty.Value);
    }
    public override void Dispose()
    {
        _sourceProperty.Unsubscribe(UpdateText);
    }

    private void UpdateText(int value)
    {
        _currentText.text = value.ToString();
    }
}
