using TMPro;
using UnityEngine;

public class GameStateInit : GameState
{
    public GameObject menuUI;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scrapCountText;

    public override void Construct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Init);

        highScoreText.text ="Highscore:" + SaveManager.Instance.save.Highscore.ToString();
        scrapCountText.text = "Scrap: " + SaveManager.Instance.save.Scrap.ToString();

        menuUI.SetActive(true);
    }

    public override void Destruct()
    {
        menuUI.SetActive(false);
    }

    public override void UpdateState()
    {

    }

    public void OnPlayClick()
    {
        GameManager.Instance.ChangeState(GameStateEnum.Game);
        GameStats.Instance.ResetSession();
        GetComponent<GameStateDeath>().EnableRevive();
    }

    public void OnShopClick()
    {
        GameManager.Instance.ChangeState(GameStateEnum.Shop);
    }
}
