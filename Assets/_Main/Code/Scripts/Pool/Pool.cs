using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class Pool<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _parent;
    private List<T> _objects;

    public Pool(T prefab, int prewarmObjects, Transform parent = null, bool activeInAwake = false)
    {
        _prefab = prefab;
        _parent = parent;
        _objects = new List<T>();

        for (int i = 0; i < prewarmObjects; i++)
        {
            var obj = GameObject.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(activeInAwake);

            _objects.Add(obj);
        }
    }
    public T Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj == null)
        {
            obj = Create();
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private T Create()
    {
        var obj = GameObject.Instantiate(_prefab, _parent);
        _objects.Add(obj);
        return obj;
    }
}
