using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKingReproduceAnimator : StateMachineBehaviour
{
    public Transform[] slimes;
    BossSlime boss_slime;
    int howMany;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss_slime = animator.GetComponent<BossSlime>();
        boss_slime.SpeedReverse(0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    /*override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }*/

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        howMany = Random.Range(3, 7);

        for (int i = 0; i < howMany; i++)
        {
            int temp = Random.Range(0, slimes.Length);
            Instantiate(slimes[temp], new Vector2(boss_slime.transform.position.x, boss_slime.transform.position.y), Quaternion.identity);
        }
        boss_slime.SpeedReverse(1);
    }
}
