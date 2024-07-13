using UnityEngine;
using System.Collections;

public class EnemyAttack : StateMachineBehaviour
{
    PlayerController playercontroller;
    
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
    }
}


