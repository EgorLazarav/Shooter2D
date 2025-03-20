using UnityEngine;

public class PropItem : MonoBehaviour, IHealth
{
    [field: SerializeField] public float Max { get; private set; }

    public float Current { get; private set; }

    private void Start()
    {
        Current = Max;
    }

    public void ApplyDamage(float value)
    {
        Current -= value;

        if (Current <= 0)
            Deactivate();
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
