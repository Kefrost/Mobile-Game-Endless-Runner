using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    private RunnerInputAction actionScheme;

    [SerializeField] private float sqrSwipeDeadzone = 50.0f;

    #region public properties
    public bool Tap { get { return tap; } }
    public Vector2 TouchPosition { get { return touchPosition; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Back { get { return back; } }
    #endregion

    #region private fields
    private bool tap;
    private Vector2 touchPosition;
    private Vector2 startDrag;
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeUp;
    private bool swipeDown;
    private bool back;
    #endregion

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        SetupControl();
    }

    private void LateUpdate()
    {
        ResetInputs();
    }

    private void ResetInputs()
    {
        tap = false;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;
        back = false;
    }

    private void SetupControl()
    {
        actionScheme = new RunnerInputAction();

        actionScheme.Gameplay.Tap.performed += ctx => OnTap(ctx);
        actionScheme.Gameplay.TouchPosition.performed += ctx => OnPosition(ctx);
        actionScheme.Gameplay.StartDrag.performed += ctx => OnStartDrag(ctx);
        actionScheme.Gameplay.EndDrag.performed += ctx => OnEndDrag(ctx);
        actionScheme.Gameplay.Back.performed += ctx => OnBack(ctx);
    }

    private void OnBack(InputAction.CallbackContext ctx)
    {
        back = true;
    }

    private void OnEndDrag(InputAction.CallbackContext ctx)
    {
        Vector2 delta = touchPosition - startDrag;
        float sqrDistance = delta.sqrMagnitude;

        if (sqrDistance > sqrSwipeDeadzone)
        {
            float x = Mathf.Abs(delta.x);
            float y = Mathf.Abs(delta.y);

            if (x > y)
            {
                if (delta.x > 0)
                {
                    swipeRight = true;
                }
                else
                {
                    swipeLeft = true;
                }
            }
            else
            {
                if (delta.y > 0)
                {
                    swipeUp = true;
                }
                else
                {
                    swipeDown = true;
                }
            }

            startDrag = Vector2.zero;
        }
    }

    private void OnStartDrag(InputAction.CallbackContext ctx)
    {
        startDrag = touchPosition;
    }

    private void OnPosition(InputAction.CallbackContext ctx)
    {
        touchPosition = ctx.ReadValue<Vector2>();
    }

    private void OnTap(InputAction.CallbackContext ctx)
    {
        tap = true;
    }

    public void OnEnable()
    {
        actionScheme.Enable();
    }

    public void OnDisable()
    {
        actionScheme.Disable();
    }
}
