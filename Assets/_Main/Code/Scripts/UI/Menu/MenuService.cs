using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class MenuService : MonoBehaviour
{
    private Dictionary<Type, Pool<MenuPanel>> _poolsMenu = new();
    private MenuPanel _currentPanel;

    public T ShowPanel<T>() where T : MenuPanel
    {
        if (_currentPanel != null)
            HideCurrentPanel();

        T panel = GetPanel<T>();
        panel.Show();
        _currentPanel = panel;

        return panel;
    }

    private T GetPanel<T>() where T : MenuPanel
    {
        if (!_poolsMenu.TryGetValue(typeof(T), out var pool))
        {
            return null;
        }

        return (T)pool.Get();
    }
    private void HideCurrentPanel()
    {
        _currentPanel.Hide();

        if (_poolsMenu.TryGetValue(_currentPanel.GetType(), out var pool))
            pool.Release(_currentPanel);

        _currentPanel = null;
    }
}
