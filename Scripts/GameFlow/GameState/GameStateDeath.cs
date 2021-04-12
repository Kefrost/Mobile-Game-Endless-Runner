using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameStateDeath : GameState, IUnityAdsListener
{
    public GameObject deathUI;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI totalScrap;
    [SerializeField] private TextMeshProUGUI currentScrap;

    [SerializeField] private Image completionCircle;
    public float timeToDecision = 2.5f;
    private float deathTime;

    private void Start()
    {
        Advertisement.AddListener(this);
    }

    public override void Construct()
    {
        GameManager.Instance.movement.PausePlayer();

        deathTime = Time.time;
        deathUI.SetActive(true);

        if (SaveManager.Instance.save.Highscore < (int)GameStats.Instance.score)
        {
            SaveManager.Instance.save.Highscore = (int)GameStats.Instance.score;
            currentScore.color = Color.green;
        }
        else
        {
            currentScore.color = Color.white;
        }

        SaveManager.Instance.save.Scrap += GameStats.Instance.scrapCollectedThisSession;
        SaveManager.Instance.Save();

        highScore.text = "Highscore: " + SaveManager.Instance.save.Highscore.ToString();
        
        int currentScoreInt = (int)GameStats.Instance.score;
        currentScore.text = currentScoreInt.ToString();
        totalScrap.text = "Total scrap: " + SaveManager.Instance.save.Scrap.ToString();
        currentScrap.text = GameStats.Instance.scrapCollectedThisSession.ToString();
    }

    public override void Destruct()
    {
        deathUI.SetActive(false);
    }

    public override void UpdateState()
    {
        float ratio = (Time.time - deathTime) / timeToDecision;
        completionCircle.color = Color.Lerp(Color.green, Color.red, ratio);
        completionCircle.fillAmount = 1 - ratio;

        if (ratio > 1)
        {
            completionCircle.gameObject.SetActive(false);
        }


    }

    public void EnableRevive()
    {
        completionCircle.gameObject.SetActive(true);
    }

    public void ToMenu()
    {
        GameManager.Instance.ChangeState(GameStateEnum.Init);
        GameManager.Instance.movement.ResetPlayer();
        GameManager.Instance.worldGeneration.ResetWorld();
        GameManager.Instance.fillGeneration.ResetWorld();
    }

    public void TryResumeGame()
    {
        AdManager.Instance.ShowRewardedAd();
    }

    public void ResumeGame()
    {
        GameManager.Instance.ChangeState(GameStateEnum.Game);
        GameManager.Instance.movement.RespawnPlayer();
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        completionCircle.gameObject.SetActive(false);

        switch (showResult)
        {
            case ShowResult.Failed:
                ToMenu();
                break;
            case ShowResult.Finished:
                ResumeGame();
                break;
            default:
                break;
        }
    }
}
