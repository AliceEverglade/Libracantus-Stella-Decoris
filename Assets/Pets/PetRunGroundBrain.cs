using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "NPCBrains/Pet/RunGround")]
public class PetRunGroundBrain : PetBrain
{
    public override void Action(Vector3 targetPos, GameObject self, PetSO data)
    {

        NavMeshAgent agent = self.GetComponent<NavMeshAgent>();
        agent.speed = data.runSpeed;
        agent.SetDestination(targetPos);
    }
}
