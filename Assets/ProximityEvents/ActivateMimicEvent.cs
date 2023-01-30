using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProximityEvents/ActivateMimic")]
public class ActivateMimicEvent : ProximityEvent
{
    public override void Activate(GameObject self, GameObject target)
    {
        // spawn mimic, destroy chest
    }
    public override void Deactivate(GameObject self, GameObject target)
    {
        //nothing
    }
}
