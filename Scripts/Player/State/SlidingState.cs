using UnityEngine;

public class SlidingState : BaseState
{
    public float slideDuration = 1.0f;

    private Vector3 initialCenter;
    private float initialSize;
    private float slideStart;

    public override void Construct()
    {
        movement.anim?.SetTrigger("Slide");
        slideStart = Time.time;

        initialSize = movement.controller.height;
        initialCenter = movement.controller.center;

        movement.controller.height = initialSize * 0.5f;
        movement.controller.center = initialCenter * 0.5f;
    }

    public override void Destruct()
    {
        movement.anim?.SetTrigger("Running");
        movement.controller.height = initialSize;
        movement.controller.center = initialCenter;
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

        if (!movement.isGrounded)
        {
            movement.verticalVelocity = -15f;
        }

        if (InputManager.Instance.SwipeUp)
        {
            movement.ChangeState(PlayerStateEnum.Jumping);
        }

        if (Time.time - slideStart > slideDuration)
        {
            movement.ChangeState(PlayerStateEnum.Running);
        }
    }

    public override Vector3 ProcessMotion()
    {

        Vector3 m = Vector3.zero;

        m.x = movement.SnapToLane();
        m.y = -1.0f;

        if (!movement.isGrounded)
        {
            movement.ApplyGravity();
            m.y = movement.verticalVelocity;
        }

        m.z = movement.currentRunSpeed;

        return m;
    }
}
