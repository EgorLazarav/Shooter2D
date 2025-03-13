using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/Weapons", fileName = "New Weapon Data", order = 54)]
public class WeaponData : ScriptableObject
{
    [field: SerializeField] public int ClipCapacity { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public float ReloadTime { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public Vector3 PositionOffset { get; private set; }
}
