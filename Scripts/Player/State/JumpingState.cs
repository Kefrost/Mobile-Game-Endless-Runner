using UnityEngine;

public class JumpingState : BaseState
{
    public float jumpForce = 7.0f;

    public override void Construct()
    {
        movement.verticalVelocity = jumpForce;
        movement.anim?.ResetTrigger("Running");
        movement.anim?.SetTrigger("Jump");
    }

    public override void Destruct()
    {

    }

    public override void Transition()
    {
        if (movement.verticalVelocity < 0)
        {
            movement.ChangeState(PlayerStateEnum.Falling);
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
