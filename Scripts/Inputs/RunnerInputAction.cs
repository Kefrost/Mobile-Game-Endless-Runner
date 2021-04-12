// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/RunnerInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @RunnerInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @RunnerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RunnerInputAction"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""2d24a7b5-132b-4650-9f8d-a4046ec43730"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""b96d69cc-8c84-40ff-b3ce-190f99c66e9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""83886a2f-426b-4ea7-b0f5-6a25107ab477"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartDrag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""053dd8b7-046e-4c5a-b619-15af260b4049"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""EndDrag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7253b321-49bc-4055-b732-ae851114df45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""b0d00306-8141-40ba-a208-7dcbe4f8dfb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc62e6ab-04ac-49e4-a196-caea58827dac"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee450c20-9841-4dc1-8475-bb33bd4c56f4"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3244f4ad-8f89-47c2-8aff-a1c2288dfd08"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bded56af-cf42-4aa3-8211-070608e51679"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bd0d84c-4869-4773-9c95-3527e0ed39ce"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""EndDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecfa32b2-e1c9-4d54-986e-3bacdb5e2674"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""EndDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a45a6082-2bc7-40dd-b3cf-f568e3beb85f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""StartDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44c6db71-2a7a-4ab0-8342-0211b0119385"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""StartDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""639c1d79-792c-4599-b509-e5c95d37a487"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ee6c318-174d-454a-abc5-279f30384b1d"",
                    ""path"": ""*/{Back}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Computer"",
            ""bindingGroup"": ""Computer"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Tap = m_Gameplay.FindAction("Tap", throwIfNotFound: true);
        m_Gameplay_TouchPosition = m_Gameplay.FindAction("TouchPosition", throwIfNotFound: true);
        m_Gameplay_StartDrag = m_Gameplay.FindAction("StartDrag", throwIfNotFound: true);
        m_Gameplay_EndDrag = m_Gameplay.FindAction("EndDrag", throwIfNotFound: true);
        m_Gameplay_Back = m_Gameplay.FindAction("Back", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Tap;
    private readonly InputAction m_Gameplay_TouchPosition;
    private readonly InputAction m_Gameplay_StartDrag;
    private readonly InputAction m_Gameplay_EndDrag;
    private readonly InputAction m_Gameplay_Back;
    public struct GameplayActions
    {
        private @RunnerInputAction m_Wrapper;
        public GameplayActions(@RunnerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Gameplay_Tap;
        public InputAction @TouchPosition => m_Wrapper.m_Gameplay_TouchPosition;
        public InputAction @StartDrag => m_Wrapper.m_Gameplay_StartDrag;
        public InputAction @EndDrag => m_Wrapper.m_Gameplay_EndDrag;
        public InputAction @Back => m_Wrapper.m_Gameplay_Back;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTap;
                @TouchPosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPosition;
                @StartDrag.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartDrag;
                @StartDrag.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartDrag;
                @StartDrag.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStartDrag;
                @EndDrag.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEndDrag;
                @EndDrag.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEndDrag;
                @EndDrag.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEndDrag;
                @Back.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @StartDrag.started += instance.OnStartDrag;
                @StartDrag.performed += instance.OnStartDrag;
                @StartDrag.canceled += instance.OnStartDrag;
                @EndDrag.started += instance.OnEndDrag;
                @EndDrag.performed += instance.OnEndDrag;
                @EndDrag.canceled += instance.OnEndDrag;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_ComputerSchemeIndex = -1;
    public InputControlScheme ComputerScheme
    {
        get
        {
            if (m_ComputerSchemeIndex == -1) m_ComputerSchemeIndex = asset.FindControlSchemeIndex("Computer");
            return asset.controlSchemes[m_ComputerSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnStartDrag(InputAction.CallbackContext context);
        void OnEndDrag(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
