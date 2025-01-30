using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T: MonoBehaviour
{
    private T _itemPrefab;
    private List<T> _pool;

    protected void InitPool(T itemPrefab)
    {
        _itemPrefab = itemPrefab;

        _pool = new List<T>();
    }

    public T Get()
    {
        T result = _pool.Find(i => i.gameObject.activeSelf == false);

        if (result == null)
        {
            result = Object.Instantiate(_itemPrefab);
            _pool.Add(result);
        }

        return result;
    }
}
