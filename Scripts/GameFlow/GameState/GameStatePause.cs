using TMPro;
using UnityEngine;

public class GameStatePause : GameState
{
    public GameObject pauseUI;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI currentScore;

    public override void Construct()
    {
        GameManager.Instance.movement.PausePlayer();

        pauseUI.SetActive(true);

        highScore.text = "Highscore: " + SaveManager.Instance.save.Highscore.ToString();
        
        int currentScoreInt = (int)GameStats.Instance.score;
        currentScore.text = currentScoreInt.ToString();
    }

    public override void Destruct()
    {
        pauseUI.SetActive(false);
    }

    public override void UpdateState()
    {

    }

    public void ResumeGame()
    {
        GameManager.Instance.ChangeState(GameStateEnum.Game);
    }
}
