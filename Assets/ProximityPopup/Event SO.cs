using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProximityEvent : ScriptableObject
{
    public abstract void Activate(GameObject self, GameObject target);
    public abstract void Deactivate(GameObject self, GameObject target);
}
