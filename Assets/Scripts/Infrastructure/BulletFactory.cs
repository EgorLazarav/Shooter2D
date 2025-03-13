using UnityEngine;

public class BulletFactory : ObjectPool<Bullet>
{
    private const string BulletPrefabPath = "Prefabs/Bullets/Bullet";

    private Bullet _bulletPrefab;

    public BulletFactory()
    {
        _bulletPrefab = Resources.Load<Bullet>(BulletPrefabPath);
        InitPool(_bulletPrefab);
    }
}
