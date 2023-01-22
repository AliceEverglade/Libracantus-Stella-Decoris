using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="NPCs/Pet")]
public class PetSO : ScriptableObject
{
    [Header("Targets")]
    public GameObject owner;
    public Vector3 offset;

    [Header("Movement")]
    public float walkSpeed;
    public float runSpeed;
    public States state;

    [Header("Misc")]
    public Types type;

    public enum States
    {
        Following,
        Running,
        Idle,
        Mounted,
        Roaming,
    }
    public enum Types
    {
        Walking,
        Flying,
        Ethereal
    }

    public void SetOwner(GameObject _owner)
    {
        this.owner = _owner;
    }
}
