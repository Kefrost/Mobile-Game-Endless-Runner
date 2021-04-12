using UnityEngine;

public class RespawnState : BaseState
{
    [SerializeField] private float verticalDistance = 25.0f;
    [SerializeField] private float immunityTime = 1f;

    private float startTime;

    public override void Construct()
    {
        startTime = Time.time;

        movement.controller.enabled = false;
        movement.transform.position = new Vector3(0, verticalDistance, movement.transform.position.z);
        movement.controller.enabled = true;

        movement.verticalVelocity = 0.0f;
        movement.currentLane = 0;
        movement.anim?.SetTrigger("Respawn");
    }

    public override void Destruct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Game);
    }

    public override void Transition()
    {
        if (movement.isGrounded && (Time.time - startTime) > immunityTime)
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
    }

    public override Vector3 ProcessMotion()
    {
        movement.ApplyGravity();

        Vector3 m = Vector3.zero;

        m.x = movement.SnapToLane();
        m.y = movement.verticalVelocity;
        m.z = movement.baseRunSpeed;

        return m;
    }
}
