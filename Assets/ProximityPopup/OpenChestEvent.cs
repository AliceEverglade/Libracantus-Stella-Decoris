using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ProximityEvents/OpenChest")]
public class OpenChestEvent : ProximityEvent
{
    public override void Activate(GameObject self, GameObject target)
    {
        Debug.Log("Open Chest");
        self.GetComponentInParent<Animator>().SetBool("isOpen", true);
        // reveal popup
        // allow opening of inventory
        // 
    }
    public override void Deactivate(GameObject self, GameObject target)
    {
        Debug.Log("Close Chest");
        self.GetComponentInParent<Animator>().SetBool("isOpen", false);
        // hide popup
        // close inventory
        //
    }
}
