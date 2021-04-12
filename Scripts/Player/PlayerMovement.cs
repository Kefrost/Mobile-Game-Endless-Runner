using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum { Running, Jumping, Falling, Sliding, Death, Respawn }

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 moveVector;
    [HideInInspector] public float verticalVelocity;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public int currentLane;

    public float distanceInBetweenLanes = 3.0f;
    public float currentRunSpeed;
    public float baseRunSpeed = 5.0f;
    public float maxRunSpeed = 15.0f;
    public float baseSpeedIncrease = 0.0002f;
    public float baseSidewaySpeed = 10.0f;
    public float gravity = 14.0f;
    public float terminalVelocity = 20.0f;

    public CharacterController controller;
    public Animator anim;

    private BaseState state;
    private bool isPaused;

    private List<BaseState> playerStates;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        playerStates = new List<BaseState>
        {
        GetComponent<RunningState>(),
        GetComponent<JumpingState>(),
        GetComponent<FallingState>(),
        GetComponent<SlidingState>(),
        GetComponent<DeathState>(),
        GetComponent<RespawnState>(),
        };

        state = playerStates[(int)PlayerStateEnum.Running];
        state.Construct();

        isPaused = true;
        isGrounded = true;
        currentRunSpeed = baseRunSpeed;
    }

    private void Update()
    {
        if (!isPaused)
        {
            UpdateMovement();
        }
        else
        {
            anim?.SetFloat("Speed", 0f);
        }
    }

    private void UpdateMovement()
    {
        isGrounded = controller.isGrounded;

        moveVector = state.ProcessMotion();

        state.Transition();

        anim?.SetBool("IsGrounded", isGrounded);
        anim?.SetFloat("Speed", Mathf.Abs(moveVector.z));

        controller.Move(moveVector * Time.deltaTime);
    }

    public float SnapToLane()
    {
        float r = 0.0f;

        if (transform.position.x != (currentLane * distanceInBetweenLanes))
        {
            float deltaToPosition = (currentLane * distanceInBetweenLanes) - transform.position.x;

            r = deltaToPosition > 0 ? 1 : -1;
            r *= baseSidewaySpeed;

            float actualDistance = r * Time.deltaTime;
            if (Mathf.Abs(actualDistance) > Mathf.Abs(deltaToPosition))
            {
                r = deltaToPosition * (1 / Time.deltaTime);
            }
        }

        return r;
    }

    public void ChangeLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, -1, 1);
    }

    public void ChangeState(PlayerStateEnum newState)
    {
        state.Destruct();
        state = playerStates[(int)newState];
        state.Construct();
    }

    public void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        if (verticalVelocity < -terminalVelocity)
        {
            verticalVelocity = -verticalVelocity;
        }
    }

    public void PausePlayer()
    {
        isPaused = true;
    }

    public void ResumePlayer()
    {
        isPaused = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string hitLayerName = LayerMask.LayerToName(hit.gameObject.layer);

        if (hitLayerName == "Death")
        {
            ChangeState(PlayerStateEnum.Death);
        }
    }

    public void RespawnPlayer()
    {
        ChangeState(PlayerStateEnum.Respawn);
        GameManager.Instance.ChangeCamera(GameCamera.Respawn);
    }

    public void ResetPlayer()
    {
        currentLane = 0;
        transform.position = Vector3.zero;
        anim?.SetTrigger("Idle");
        ChangeState(PlayerStateEnum.Running);
        PausePlayer();
        currentRunSpeed = baseRunSpeed;
    }
}
