using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public sealed class ImageFillView : ContentView
{
    [SerializeField] private Image _currentImage;

    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private Ease _easeType = Ease.OutQuad;

    private ReactiveProperty<float> _sourceProperty;
    private Tweener _currentTween;

    public void Bind(ReactiveProperty<float> property)
    {
        _sourceProperty = property;
    }
    public override void Initialize()
    {
        if (_currentImage == null)
            _currentImage = GetComponent<Image>();

        _sourceProperty.Subscribe(UpdateImage);

        _currentImage.fillAmount = _sourceProperty.Value;
    }
    public override void Dispose()
    {
        _currentTween?.Kill();

        _sourceProperty.Unsubscribe(UpdateImage);
    }

    private void UpdateImage(float value)
    {
        _currentTween?.Kill();

        if (Mathf.Abs(_currentImage.fillAmount - value) < 0.001f)
        {
            _currentImage.fillAmount = value;
            return;
        }

        _currentTween = DOTween.To(() => _currentImage.fillAmount,x => _currentImage.fillAmount = x,value,_animationDuration)
            .SetEase(_easeType);
    }
}
