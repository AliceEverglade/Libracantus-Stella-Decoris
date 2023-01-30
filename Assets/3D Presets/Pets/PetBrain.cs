using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetBrain : ScriptableObject
{
    public virtual void Action(Vector3 targetPos)
    {
        //do something with a location
    }
    public virtual void Action(Vector3 targetPos, GameObject self)
    {
        // do something with a location and access the Pet's Gameobject
    }
    public virtual void Action(Vector3 targetPos, GameObject self, PetSO data)
    {
        // do something with a location and access the Pet's Gameobject and data
    }
    public virtual void Action(Vector3 targetPos, GameObject self, PetSO data, GameObject target)
    {
        // do something with a location, access the Pet's Gameobject and a target's GameObject
    }
}
