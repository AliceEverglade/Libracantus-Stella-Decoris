using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProximityEventHandler : MonoBehaviour
{
    [SerializeField] private ProximityEvent action;
    [SerializeField] private string tag;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag(tag))
        {
            action.Activate(this.gameObject, hit.gameObject);
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.CompareTag(tag))
        {
            action.Deactivate(this.gameObject, hit.gameObject);
        }
    }
}
