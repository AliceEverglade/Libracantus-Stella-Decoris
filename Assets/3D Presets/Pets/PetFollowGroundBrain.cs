using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "NPCBrains/Pet/FollowGround")]
public class PetFollowGroundBrain : PetBrain
{
    public override void Action(Vector3 targetPos,GameObject self, PetSO data)
    {

        NavMeshAgent agent = self.GetComponent<NavMeshAgent>();
        agent.speed = data.walkSpeed;
        agent.SetDestination(targetPos);
    }
}
