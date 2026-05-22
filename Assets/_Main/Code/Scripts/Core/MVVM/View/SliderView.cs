using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class SliderView : ContentView
{
    [SerializeField] private Slider _currentSlider;

    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private Ease _easeType = Ease.Flash;

    private ReactiveProperty<float> _sourceProperty;
    private Tweener _currentTween;

    public void Bind(ReactiveProperty<float> property)
    {
        _sourceProperty = property;
    }

    public override void Initialize()
    {
        if (_currentSlider == null)
            _currentSlider = GetComponent<Slider>();

        _sourceProperty.Subscribe(UpdateSlider);
        _currentSlider.value = _sourceProperty.Value;
    }

    public override void Dispose()
    {
        _currentTween?.Kill();

        _sourceProperty.Unsubscribe(UpdateSlider);
    }

    private void UpdateSlider(float value)
    {
        _currentTween?.Kill();

        if (Mathf.Abs(_currentSlider.value - value) < 0.001f)
        {
            _currentSlider.value = value;
            return;
        }

        _currentTween = DOTween.To(() => _currentSlider.value,x => _currentSlider.value = x,value,_animationDuration)
            .SetEase(_easeType);
    }
}
