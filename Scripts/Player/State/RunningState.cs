using UnityEngine;

public class RunningState : BaseState
{
    public override void Construct()
    {
        movement.verticalVelocity = 0f;
    }

    public override void Destruct()
    {

    }

    public override void Transition()
    {
        if (InputManager.Instance.SwipeLeft)
        {
            movement.ChangeLane(-1);
        }

        if (InputManager.Instance.SwipeRight)
        {
            movement.ChangeLane(1);
        }

        if (InputManager.Instance.SwipeUp && movement.isGrounded)
        {
            movement.ChangeState(PlayerStateEnum.Jumping);
        }

        if (InputManager.Instance.SwipeDown)
        {
            movement.ChangeState(PlayerStateEnum.Sliding);
        }

        if (!movement.isGrounded)
        {
            movement.ChangeState(PlayerStateEnum.Falling);
        }
    }

    public override Vector3 ProcessMotion()
    {
        movement.currentRunSpeed += movement.baseSpeedIncrease;
        if (movement.currentRunSpeed >= movement.maxRunSpeed)
        {
            movement.currentRunSpeed = movement.maxRunSpeed;
        }
        Vector3 m = Vector3.zero;

        m.x = movement.SnapToLane();
        m.y = -1f;
        m.z = movement.currentRunSpeed;

        return m;
    }
}
