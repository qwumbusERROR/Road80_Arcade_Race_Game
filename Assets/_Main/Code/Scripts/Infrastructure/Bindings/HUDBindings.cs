using UnityEngine;

public class HUDBindings : MonoBehaviour
{
    [SerializeField] private VehicleHealthUIBindings _vehicleHealth;

    private HealthModel _model;
    private HealthViewModel _viewModel;

    private void Start()
    {
        _model = new HealthModel(100, 100);
        _viewModel = new HealthViewModel(_model);

        _vehicleHealth.Initialize(_viewModel);

    }
}
