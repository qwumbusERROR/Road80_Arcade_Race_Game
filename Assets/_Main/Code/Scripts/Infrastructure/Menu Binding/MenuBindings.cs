using UnityEngine;

public class MenuBindings : MonoBehaviour
{
    [SerializeField] private MenuService _menuService;

    private void Start()
    {
        _menuService.Initialize();
    }
}
