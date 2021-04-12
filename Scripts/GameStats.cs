using System;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance{ get { return instance; } }
    private static GameStats instance;

    //Score
    public float score;
    public float highscore;
    public float distanceModifier = 1.5f;

    // Collectible
    public int totalScrap;
    public int scrapCollectedThisSession;
    public float pointsPerScrap = 10.0f;

    //Internal Cooldown
    private float lastScoreUpdate;
    private float scoreUpdateDelta = 0.2f;

    //Action
    public Action<int> OnCollectScrap;
    public Action<float> OnScoreChange;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        float s = GameManager.Instance.movement.transform.position.z * distanceModifier;
        s += scrapCollectedThisSession * pointsPerScrap;

        if (s > score)
        {
            score = s;

            if (Time.time - lastScoreUpdate > scoreUpdateDelta)
            {
                lastScoreUpdate = Time.time;
                OnScoreChange?.Invoke(score); 
            }
        }


    }

    public void CollectScrap()
    {
        scrapCollectedThisSession++;
        OnCollectScrap?.Invoke(scrapCollectedThisSession);
    }

    public void ResetSession()
    {
        score = 0;
        scrapCollectedThisSession = 0;

        OnCollectScrap?.Invoke(scrapCollectedThisSession);
        OnScoreChange?.Invoke(score);
    }
}
