using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKingMovementAnimator : StateMachineBehaviour
{
    Transform player;
    BossSlime boss_slime;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss_slime = animator.GetComponent<BossSlime>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.position, rb.position) <= boss_slime.attackRange)
            animator.SetTrigger("AttackRange");

        if (boss_slime.currentHealth <= 0)
            animator.SetTrigger("IsDead");

        int r = Random.Range(1, 1000);
        if (r == 1)
            animator.SetTrigger("MoreSlimes");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AttackRange");
        animator.ResetTrigger("IsDead");
        animator.ResetTrigger("MoreSlimes");
    }
}
