using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    private float chunkSpawnZ;
    private Queue<Chunk> activeChunks = new Queue<Chunk>();
    private List<Chunk> chunkPool = new List<Chunk>();

    [SerializeField] private int firstChunkSpawnPosition = -10;
    [SerializeField] private int chunksOnScreen = 5;
    [SerializeField] private float despawnDistance = 5.0f;

    [SerializeField] private List<Chunk> chunkPrefabs;
    [SerializeField] private Transform cameraTransform;

    private void Awake()
    {
        ResetWorld();
    }
    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
            Debug.Log("cameraTransform is set to default Cam!");
        }

        if (chunkPrefabs.Count == 0)
        {
            Debug.LogError("No chunk prefabs found!");
            return;
        }
    }

    public void ScanPosition()
    {
        float cameraZ = cameraTransform.position.z;
        Chunk lastChunk = activeChunks.Peek();

        if (cameraZ >= lastChunk.transform.position.z + lastChunk.chunkLenght + despawnDistance)
        {
            SpawnNewChunk();
            DeleteLastChunk();
        }
    }

    private void SpawnNewChunk()
    {
        int randomIndex = Random.Range(0, chunkPrefabs.Count);

        Debug.Log($"random index of {this} is {randomIndex}");

        Chunk chunk = chunkPool.Find(c => !c.gameObject.activeSelf && c.index == chunkPrefabs[randomIndex].index);

        if (chunk == null)
        {
            GameObject obj = Instantiate(chunkPrefabs[randomIndex].gameObject, transform);
            chunk = obj.GetComponent<Chunk>();
        }

        chunk.transform.position = new Vector3(0, 0, chunkSpawnZ);
        chunkSpawnZ += chunk.chunkLenght;

        activeChunks.Enqueue(chunk);
        chunk.ShowChunk();
    }

    private void DeleteLastChunk()
    {
        Chunk chunk = activeChunks.Dequeue();
        chunk.HideChunk();
        chunkPool.Add(chunk);
    }

    public void ResetWorld()
    {
        chunkSpawnZ = firstChunkSpawnPosition;

        while(activeChunks.Count != 0)
        {
            DeleteLastChunk();
        }

        for (int i = 0; i < chunksOnScreen; i++)
        {
            SpawnNewChunk();
        }
    }
}
