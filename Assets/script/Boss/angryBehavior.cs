using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryBehavior : StateMachineBehaviour
{
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.GetComponent<BossHealth>().isInvulnerble = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.GetComponent<BossHealth>().isInvulnerble = false;
    }
}
