using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickACoin : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(GameManager.instance.isCoinPicked)
            animator.SetTrigger("CoinPicked");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.instance.isCoinPicked = false;
        animator.ResetTrigger("CoinPicked");
    }
}
