using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAttackState : State
{
    public Transform target;
    public NavigateState navigateState;
    public IdleState idleState;
    public float vision = 1;
    public float attackRange = 1;

    public override void Enter()
    {
        navigateState.destination = target.position;
        Set(navigateState, true);
    }

    public override void Do()
    {
        ChaseTarget();
    }

    void ChaseTarget()
    {
        // check if target is dead by checking if gameobject is active
        if (!target.gameObject.activeSelf)
        {
            target = null;
            Set(idleState, true);
            body.linearVelocity = new Vector2(0, body.linearVelocity.y);
        }
        // could code a ram attack here
        else if (IsWithinReach(target.position))
        {
            // Set(attackState, state != attackState);
            // trigger attach here
            body.linearVelocity = new Vector2(0, body.linearVelocity.y);
        }
        else
        {
            //otherwise, keep chasing
            navigateState.destination = target.position;
            Set(navigateState, true);
        }
    }

    void EndPursuit()
    {
        // can add some custom behavior here
        // but this exits the chase state
        isComplete = true;
    }

    public override void Exit()
    {

    }

    public bool IsInVision(Vector2 targetPos)
    {
        return Vector2.Distance(core.transform.position, targetPos) < vision;
    }

    public bool IsWithinReach(Vector2 targetPos)
    {
        return Vector2.Distance(core.transform.position, targetPos) < attackRange;
    }

    public void CheckForTarget()
    {
        // if (EnemyDetection.ShouldChaseTarget())
        // {
        //     target = EnemyDetection.Target.transform;
        //     return;
        // }

        target = null;
    }
}