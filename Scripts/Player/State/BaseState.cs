using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected PlayerMovement movement;

    public abstract void Construct();
    public abstract void Destruct();
    public abstract void Transition();

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public virtual Vector3 ProcessMotion()
    {
        Debug.Log("Process motion is not implemented in ");
        return Vector3.zero;
    }
}