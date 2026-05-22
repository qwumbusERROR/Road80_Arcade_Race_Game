using UnityEngine;

public class VehicleHealthUIBindings : MonoBehaviour
{
    [SerializeField] private TextView _textView;

    private HealthViewModel _healthViewModel;

    public void Initialize(HealthViewModel viewModel)
    {
        _healthViewModel = viewModel;

        _textView.Bind(_healthViewModel.CurrentHealth);

        _textView.Initialize();

        _healthViewModel.Initialize();
    }

    private void OnDestroy()
    {
        _textView.Dispose();

        _healthViewModel.Dispose();
    }
}
