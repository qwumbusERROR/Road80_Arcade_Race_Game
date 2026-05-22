using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextView : ContentView
{
    [SerializeField] private TextMeshProUGUI _currentText;

    [SerializeField] private float _animationDuration = 0.6f;     
    [SerializeField] private Ease _easeType = Ease.OutQuad;     

    private ReactiveProperty<int> _sourceProperty;
    private Tweener _currentTween;
    private int _currentDisplayedValue;

    public void Bind(ReactiveProperty<int> property)
    {
        _sourceProperty = property;

        if (_currentText == null)
            _currentText = GetComponent<TextMeshProUGUI>();
    }

    public override void Initialize()
    {
        _sourceProperty.Subscribe(UpdateText);

        _currentDisplayedValue = _sourceProperty.Value;
        _currentText.text = _currentDisplayedValue.ToString();
    }
    public override void Dispose()
    {
        _currentTween?.Kill();

        _sourceProperty.Unsubscribe(UpdateText);
    }

    private void UpdateText(int value)
    {
        _currentTween?.Kill();

        if (_currentDisplayedValue == value)
        {
            _currentText.text = value.ToString();
            return;
        }

        _currentTween = DOTween.To(() => _currentDisplayedValue,x =>{_currentDisplayedValue = x;
                _currentText.text = _currentDisplayedValue.ToString();},value,_animationDuration)
            .SetEase(_easeType)
            .OnComplete(() => _currentDisplayedValue = value);
    }
}
