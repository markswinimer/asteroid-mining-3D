using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateState : State
{
    public Vector2 destination;
    public float speed = 1;
    public float threshold = 1f;

    public State animation;

    public override void Enter()
    {
        Set(animation, true);
    }

    public override void Do()
    {
        if (Vector2.Distance(core.transform.position, destination) < threshold)
        {
            isComplete = true;
        }
        FaceDestination();
    }

    public override void FixedDo()
    {
        Vector2 direction = (destination - (Vector2)core.transform.position).normalized;
        body.linearVelocity = new Vector2(Mathf.Sign(direction.x) * speed, body.linearVelocity.y);
    }

    void FaceDestination()
    {
        core.transform.localScale = new Vector3(Mathf.Sign(body.linearVelocity.x), 1, 1);
    }
}