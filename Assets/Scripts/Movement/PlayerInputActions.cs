//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/Movement/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""4fb6a393-0a0b-4c2c-ae96-45ff5a8792e0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""39291294-decc-4bde-828e-d02f5e0e1c71"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""0c02acad-80d1-4a54-949e-baefddab88d5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryAction"",
                    ""type"": ""Button"",
                    ""id"": ""6030ad00-15b1-4c52-97de-bdf0f91de944"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryAction"",
                    ""type"": ""Button"",
                    ""id"": ""db015fdf-eb2b-45ff-9c1d-526931ff9396"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact1"",
                    ""type"": ""Button"",
                    ""id"": ""fac85392-9cd4-4c47-a8da-8911e5b74689"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact2"",
                    ""type"": ""Button"",
                    ""id"": ""583092ba-4215-4d9e-b117-e31163f542b3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""978bfe49-cc26-4a3d-ab7b-7d7a29327403"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""00ca640b-d935-4593-8157-c05846ea39b3"",
                    ""path"": ""Dpad(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2062cb9-1b15-46a2-838c-2f8d72a0bdd9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8180e8bd-4097-4f4e-ab88-4523101a6ce9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""320bffee-a40b-4347-ac70-c210eb8bc73a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c5327b5-f71c-4f60-99c7-4e737386f1d1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d2581a9b-1d11-4566-b27d-b92aff5fabbc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2e46982e-44cc-431b-9f0b-c11910bf467a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcfe95b8-67b9-4526-84b5-5d0bc98d6400"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""77bff152-3580-4b21-b6de-dcd0c7e41164"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3ea4d645-4504-4529-b061-ab81934c3752"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38b915c4-ac0b-4dbf-a6cd-cc7470d3cad5"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19f4a3a7-3e3d-4e43-bccb-dbbfe723a1ae"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4273a46-84a3-400b-9cd7-80cdba767aec"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0568f55d-4e6c-420d-84e7-9c855eddb769"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""PrimaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05acc046-9d65-4c83-96c5-15b09421f6ab"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PrimaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07032d07-d8d0-4b07-a29d-6091ea252e06"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13f43569-8981-4c2d-83eb-cbf0c247c466"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e526e35-1c2e-462a-a5ab-b615974b5ce6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""958c5f27-6ff3-4f41-ab13-97c222a23713"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GeneralInteraction"",
            ""id"": ""7fdedb21-ca88-472d-b3ab-5f0f7a202935"",
            ""actions"": [
                {
                    ""name"": ""Interact1"",
                    ""type"": ""Button"",
                    ""id"": ""eee56597-60ae-45f5-9d01-95bedf1e7893"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact2"",
                    ""type"": ""Button"",
                    ""id"": ""4941d012-05f0-4b63-96db-f346c7fbc0b6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a978ada-72a9-4883-9567-ade0290464b2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12146dbb-6f0d-41a1-84d6-4cd070e654ae"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""StationProximity"",
            ""id"": ""ed279409-bf4d-41b3-8b0b-3218dfdc8d92"",
            ""actions"": [
                {
                    ""name"": ""ReleaseOre"",
                    ""type"": ""Button"",
                    ""id"": ""b68608bc-2b3b-486d-8a89-d244d5088dbb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bbb5e2f4-7e8e-490f-b455-7590401f7b4d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseOre"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Boost = m_Player.FindAction("Boost", throwIfNotFound: true);
        m_Player_PrimaryAction = m_Player.FindAction("PrimaryAction", throwIfNotFound: true);
        m_Player_SecondaryAction = m_Player.FindAction("SecondaryAction", throwIfNotFound: true);
        m_Player_Interact1 = m_Player.FindAction("Interact1", throwIfNotFound: true);
        m_Player_Interact2 = m_Player.FindAction("Interact2", throwIfNotFound: true);
        // GeneralInteraction
        m_GeneralInteraction = asset.FindActionMap("GeneralInteraction", throwIfNotFound: true);
        m_GeneralInteraction_Interact1 = m_GeneralInteraction.FindAction("Interact1", throwIfNotFound: true);
        m_GeneralInteraction_Interact2 = m_GeneralInteraction.FindAction("Interact2", throwIfNotFound: true);
        // StationProximity
        m_StationProximity = asset.FindActionMap("StationProximity", throwIfNotFound: true);
        m_StationProximity_ReleaseOre = m_StationProximity.FindAction("ReleaseOre", throwIfNotFound: true);
    }

    ~@PlayerInputActions()
    {
        UnityEngine.Debug.Assert(!m_Player.enabled, "This will cause a leak and performance issues, PlayerInputActions.Player.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_GeneralInteraction.enabled, "This will cause a leak and performance issues, PlayerInputActions.GeneralInteraction.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_StationProximity.enabled, "This will cause a leak and performance issues, PlayerInputActions.StationProximity.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Boost;
    private readonly InputAction m_Player_PrimaryAction;
    private readonly InputAction m_Player_SecondaryAction;
    private readonly InputAction m_Player_Interact1;
    private readonly InputAction m_Player_Interact2;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Boost => m_Wrapper.m_Player_Boost;
        public InputAction @PrimaryAction => m_Wrapper.m_Player_PrimaryAction;
        public InputAction @SecondaryAction => m_Wrapper.m_Player_SecondaryAction;
        public InputAction @Interact1 => m_Wrapper.m_Player_Interact1;
        public InputAction @Interact2 => m_Wrapper.m_Player_Interact2;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Boost.started += instance.OnBoost;
            @Boost.performed += instance.OnBoost;
            @Boost.canceled += instance.OnBoost;
            @PrimaryAction.started += instance.OnPrimaryAction;
            @PrimaryAction.performed += instance.OnPrimaryAction;
            @PrimaryAction.canceled += instance.OnPrimaryAction;
            @SecondaryAction.started += instance.OnSecondaryAction;
            @SecondaryAction.performed += instance.OnSecondaryAction;
            @SecondaryAction.canceled += instance.OnSecondaryAction;
            @Interact1.started += instance.OnInteract1;
            @Interact1.performed += instance.OnInteract1;
            @Interact1.canceled += instance.OnInteract1;
            @Interact2.started += instance.OnInteract2;
            @Interact2.performed += instance.OnInteract2;
            @Interact2.canceled += instance.OnInteract2;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Boost.started -= instance.OnBoost;
            @Boost.performed -= instance.OnBoost;
            @Boost.canceled -= instance.OnBoost;
            @PrimaryAction.started -= instance.OnPrimaryAction;
            @PrimaryAction.performed -= instance.OnPrimaryAction;
            @PrimaryAction.canceled -= instance.OnPrimaryAction;
            @SecondaryAction.started -= instance.OnSecondaryAction;
            @SecondaryAction.performed -= instance.OnSecondaryAction;
            @SecondaryAction.canceled -= instance.OnSecondaryAction;
            @Interact1.started -= instance.OnInteract1;
            @Interact1.performed -= instance.OnInteract1;
            @Interact1.canceled -= instance.OnInteract1;
            @Interact2.started -= instance.OnInteract2;
            @Interact2.performed -= instance.OnInteract2;
            @Interact2.canceled -= instance.OnInteract2;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // GeneralInteraction
    private readonly InputActionMap m_GeneralInteraction;
    private List<IGeneralInteractionActions> m_GeneralInteractionActionsCallbackInterfaces = new List<IGeneralInteractionActions>();
    private readonly InputAction m_GeneralInteraction_Interact1;
    private readonly InputAction m_GeneralInteraction_Interact2;
    public struct GeneralInteractionActions
    {
        private @PlayerInputActions m_Wrapper;
        public GeneralInteractionActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact1 => m_Wrapper.m_GeneralInteraction_Interact1;
        public InputAction @Interact2 => m_Wrapper.m_GeneralInteraction_Interact2;
        public InputActionMap Get() { return m_Wrapper.m_GeneralInteraction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralInteractionActions set) { return set.Get(); }
        public void AddCallbacks(IGeneralInteractionActions instance)
        {
            if (instance == null || m_Wrapper.m_GeneralInteractionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GeneralInteractionActionsCallbackInterfaces.Add(instance);
            @Interact1.started += instance.OnInteract1;
            @Interact1.performed += instance.OnInteract1;
            @Interact1.canceled += instance.OnInteract1;
            @Interact2.started += instance.OnInteract2;
            @Interact2.performed += instance.OnInteract2;
            @Interact2.canceled += instance.OnInteract2;
        }

        private void UnregisterCallbacks(IGeneralInteractionActions instance)
        {
            @Interact1.started -= instance.OnInteract1;
            @Interact1.performed -= instance.OnInteract1;
            @Interact1.canceled -= instance.OnInteract1;
            @Interact2.started -= instance.OnInteract2;
            @Interact2.performed -= instance.OnInteract2;
            @Interact2.canceled -= instance.OnInteract2;
        }

        public void RemoveCallbacks(IGeneralInteractionActions instance)
        {
            if (m_Wrapper.m_GeneralInteractionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGeneralInteractionActions instance)
        {
            foreach (var item in m_Wrapper.m_GeneralInteractionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GeneralInteractionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GeneralInteractionActions @GeneralInteraction => new GeneralInteractionActions(this);

    // StationProximity
    private readonly InputActionMap m_StationProximity;
    private List<IStationProximityActions> m_StationProximityActionsCallbackInterfaces = new List<IStationProximityActions>();
    private readonly InputAction m_StationProximity_ReleaseOre;
    public struct StationProximityActions
    {
        private @PlayerInputActions m_Wrapper;
        public StationProximityActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReleaseOre => m_Wrapper.m_StationProximity_ReleaseOre;
        public InputActionMap Get() { return m_Wrapper.m_StationProximity; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StationProximityActions set) { return set.Get(); }
        public void AddCallbacks(IStationProximityActions instance)
        {
            if (instance == null || m_Wrapper.m_StationProximityActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StationProximityActionsCallbackInterfaces.Add(instance);
            @ReleaseOre.started += instance.OnReleaseOre;
            @ReleaseOre.performed += instance.OnReleaseOre;
            @ReleaseOre.canceled += instance.OnReleaseOre;
        }

        private void UnregisterCallbacks(IStationProximityActions instance)
        {
            @ReleaseOre.started -= instance.OnReleaseOre;
            @ReleaseOre.performed -= instance.OnReleaseOre;
            @ReleaseOre.canceled -= instance.OnReleaseOre;
        }

        public void RemoveCallbacks(IStationProximityActions instance)
        {
            if (m_Wrapper.m_StationProximityActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStationProximityActions instance)
        {
            foreach (var item in m_Wrapper.m_StationProximityActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StationProximityActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StationProximityActions @StationProximity => new StationProximityActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnPrimaryAction(InputAction.CallbackContext context);
        void OnSecondaryAction(InputAction.CallbackContext context);
        void OnInteract1(InputAction.CallbackContext context);
        void OnInteract2(InputAction.CallbackContext context);
    }
    public interface IGeneralInteractionActions
    {
        void OnInteract1(InputAction.CallbackContext context);
        void OnInteract2(InputAction.CallbackContext context);
    }
    public interface IStationProximityActions
    {
        void OnReleaseOre(InputAction.CallbackContext context);
    }
}
