using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    public abstract void Construct();
    public abstract void Destruct();
    public abstract void UpdateState();
}
