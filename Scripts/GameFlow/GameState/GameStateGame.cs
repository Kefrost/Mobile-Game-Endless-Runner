using TMPro;
using UnityEngine;

public class GameStateGame : GameState
{
    public GameObject gameUI;
    [SerializeField] private TextMeshProUGUI scrapCount;
    [SerializeField] private TextMeshProUGUI scoreCount;

    public override void Construct()
    {
        GameManager.Instance.movement.ResumePlayer();
        GameManager.Instance.ChangeCamera(GameCamera.Game);

        GameStats.Instance.OnCollectScrap += UpdateScrapCount;
        GameStats.Instance.OnScoreChange += UpdateScore;

        gameUI.SetActive(true);
    }

    private void UpdateScrapCount(int amount)
    {
        scrapCount.text = amount.ToString("000");
    }

    private void UpdateScore(float amount)
    {
        scoreCount.text = amount.ToString("000000");
    }

    public override void Destruct()
    {
        gameUI.SetActive(false);

        GameStats.Instance.OnCollectScrap -= UpdateScrapCount;
        GameStats.Instance.OnScoreChange -= UpdateScore;
    }

    public override void UpdateState()
    {
        GameManager.Instance.worldGeneration.ScanPosition();
        GameManager.Instance.fillGeneration.ScanPosition();

        if (InputManager.Instance.Back)
        {
            GameManager.Instance.ChangeState(GameStateEnum.Pause);
        }
    }
}
