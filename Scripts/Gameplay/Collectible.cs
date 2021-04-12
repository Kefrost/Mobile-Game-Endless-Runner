using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickupCollectible();
        }
    }

    private void PickupCollectible()
    {
        anim?.SetTrigger("Pickup");
        GameStats.Instance.CollectScrap();
    }

    public void OnShowChunk()
    {
        anim?.SetTrigger("Idle");
    }
}
