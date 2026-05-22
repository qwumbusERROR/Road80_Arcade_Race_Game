using UnityEngine;

public class VehicleHealthUIBindings : MonoBehaviour
{
    [SerializeField] private TextView _textView;
    [SerializeField] private SliderView _sliderView;
    [SerializeField] private ImageFillView _imageView;

    private HealthViewModel _healthViewModel;

    public void Initialize(HealthViewModel viewModel)
    {
        _healthViewModel = viewModel;

        _textView.Bind(_healthViewModel.CurrentHealth);
        _sliderView.Bind(_healthViewModel.Normalized);
        _imageView.Bind(_healthViewModel.Normalized);

        _textView.Initialize();
        _sliderView.Initialize();
        _imageView.Initialize();

        _healthViewModel.Initialize();
    }

    private void OnDestroy()
    {
        _textView.Dispose();

        _healthViewModel.Dispose();
    }
}
