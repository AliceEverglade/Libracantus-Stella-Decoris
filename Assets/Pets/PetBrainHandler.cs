using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBrainHandler : MonoBehaviour
{
    [SerializeField] private GameObject owner;
    [SerializeField] private PetSO data;
    [SerializeField] private Vector3 target;
    [SerializeField] private PetBrain brain;
    // Start is called before the first frame update
    void Start()
    {
        data.SetOwner(owner);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (data.state)
        {
            case PetSO.States.Following:
                target = data.owner.transform.position + data.offset;
                brain.Action(target, gameObject, data);
                break;
            case PetSO.States.Idle:

                break;
            case PetSO.States.Running:
                target = data.owner.transform.position + data.offset;
                brain.Action(target, gameObject, data); //but select a different brain
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(owner.transform.position + data.offset, 0.1f);
    }
}
