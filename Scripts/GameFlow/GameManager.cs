using System.Collections.Generic;
using UnityEngine;

public enum GameCamera { Init, Game, Shop, Respawn}
public enum GameStateEnum { Init, Game, Shop, Pause, Death}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;

    public PlayerMovement movement;
    public WorldGeneration worldGeneration;
    public FillGeneration fillGeneration;
    public GameObject[] cameras;

    private GameState state;

    private List<GameState> gameStates;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        gameStates = new List<GameState> 
        {
        GetComponent<GameStateInit>(),
        GetComponent<GameStateGame>(),
        GetComponent<GameStateShop>(),
        GetComponent<GameStatePause>(),
        GetComponent<GameStateDeath>(),
        };

        state = gameStates[(int)GameStateEnum.Init];
        state.Construct();
    }

    private void Update()
    {
        state.UpdateState();
    }

    public void ChangeState(GameStateEnum newState)
    {
        state.Destruct();
        state = gameStates[(int)newState];
        state.Construct();
    }

    public void ChangeCamera(GameCamera cam)
    {
        foreach (GameObject obj in cameras)
        {
            obj.SetActive(false);
        }

        cameras[(int)cam].SetActive(true);
    }
}
