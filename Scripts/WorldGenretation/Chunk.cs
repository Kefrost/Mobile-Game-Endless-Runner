using UnityEngine;

public class Chunk : MonoBehaviour
{
    public float chunkLenght;
    public int index;

    public Chunk ShowChunk()
    {
        transform.gameObject.BroadcastMessage("OnShowChunk", SendMessageOptions.DontRequireReceiver);
        gameObject.SetActive(true);
        return this;
    }
    public Chunk HideChunk()
    {
        gameObject.SetActive(false);
        return this;
    }
}
