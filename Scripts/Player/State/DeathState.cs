using UnityEngine;

public class DeathState : BaseState
{
    [SerializeField] private Vector3 knockBackForce = new Vector3(0, 4, -3);
    private Vector3 currentKnockBack;

    public override void Construct()
    {
        movement.anim?.SetTrigger("Death");
        currentKnockBack = knockBackForce; 
    }

    public override void Destruct()
    {

    }

    public override void Transition()
    {

    }

    public override Vector3 ProcessMotion()
    {
        currentKnockBack = new Vector3(
            0,
            currentKnockBack.y -= movement.gravity * Time.deltaTime,
            currentKnockBack.z += 2.0f * Time.deltaTime);

        if (currentKnockBack.z > 0)
        {
            currentKnockBack.z = 0;
            GameManager.Instance.ChangeState(GameStateEnum.Death);
        }

        return currentKnockBack;
    }
}
