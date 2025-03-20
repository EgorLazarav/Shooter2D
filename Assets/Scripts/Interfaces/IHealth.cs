using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{ 
    public float Max { get; }
    public float Current { get; }

    public void ApplyDamage(float value);
}
