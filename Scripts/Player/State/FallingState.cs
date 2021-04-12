using UnityEngine;

public class FallingState : BaseState
{
    public override void Construct()
    {
        movement.anim?.SetTrigger("Fall");
    }

    public override void Destruct()
    {

    }

    public override void Transition()
    {
        if (movement.isGrounded)
        {
            movement.ChangeState(PlayerStateEnum.Running);
        }

        if (InputManager.Instance.SwipeLeft)
        {
            movement.ChangeLane(-1);
        }

        if (InputManager.Instance.SwipeRight)
        {
            movement.ChangeLane(1);
        }

        if (InputManager.Instance.SwipeDown)
        {
            movement.ChangeState(PlayerStateEnum.Sliding);
        }
    }

    public override Vector3 ProcessMotion()
    {
        movement.ApplyGravity();

        Vector3 m = Vector3.zero;

        m.x = movement.SnapToLane();
        m.y = movement.verticalVelocity;
        m.z = movement.currentRunSpeed;

        return m;
    }
}
