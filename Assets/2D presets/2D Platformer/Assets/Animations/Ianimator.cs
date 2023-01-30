using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ianimator
{
    public void UpdateAnimation(GameObject target, string animation)
    {
        if(target.GetComponent<Animator>() != null)
        {
            target.GetComponent<Animator>().Play(animation);
        }
    }
}
