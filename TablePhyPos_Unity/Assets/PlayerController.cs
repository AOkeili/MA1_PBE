// GENERATED AUTOMATICALLY FROM 'Assets/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""d4684758-64e6-42bf-839b-eb4dc2153bf8"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Value"",
                    ""id"": ""76b83862-396f-4493-a898-e5eb742b718b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""df45de37-1a85-4c47-a1f6-292447476009"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""739eb3a9-cb2c-4369-8194-ba84b26dbdf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kill"",
                    ""type"": ""Button"",
                    ""id"": ""5027807a-647a-4c1e-8285-38e261c91b25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TestTakeDamage"",
                    ""type"": ""Button"",
                    ""id"": ""224d500b-c389-4f11-ac1a-178f37e024d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TestKillEnemy"",
                    ""type"": ""Button"",
                    ""id"": ""14dfdf76-4ffc-4fe7-b888-0811bccb3b4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a6f2162b-ddf2-463a-a711-d67fd4a058e6"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""702e699d-8da1-4b97-af3f-de4502c580fd"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e81efbb7-2277-43f7-aea9-2b9a686b7f7a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ddc64f6-c98b-47b7-9c88-8450a7f42a50"",
                    ""path"": ""<HID::Logitech Logitech Extreme 3D>/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""846ca3f3-c971-43ac-a991-17665fed1c71"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ebd2a90-ebeb-4e9a-b569-c50b08776d03"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c0f5257-d570-4c3c-a2c2-82d791422cbd"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b1d7c99-956e-40af-aea4-99eb422b9654"",
                    ""path"": ""<HID::Logitech Logitech Extreme 3D>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b1126ed-2c47-4390-a819-bb71d00c0c37"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d92c567-828f-46c0-b41a-dc586e88f6a4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04bab676-eb07-4ff8-9a04-fbf269cb471b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestTakeDamage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94f3b409-50f1-4261-baf4-9515bc12da3c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestTakeDamage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1ba1665-653e-493e-b6f9-d1e0cc54bc41"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestKillEnemy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Forward = m_Gameplay.FindAction("Forward", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_Fire = m_Gameplay.FindAction("Fire", throwIfNotFound: true);
        m_Gameplay_Kill = m_Gameplay.FindAction("Kill", throwIfNotFound: true);
        m_Gameplay_TestTakeDamage = m_Gameplay.FindAction("TestTakeDamage", throwIfNotFound: true);
        m_Gameplay_TestKillEnemy = m_Gameplay.FindAction("TestKillEnemy", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Forward;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_Fire;
    private readonly InputAction m_Gameplay_Kill;
    private readonly InputAction m_Gameplay_TestTakeDamage;
    private readonly InputAction m_Gameplay_TestKillEnemy;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Gameplay_Forward;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @Fire => m_Wrapper.m_Gameplay_Fire;
        public InputAction @Kill => m_Wrapper.m_Gameplay_Kill;
        public InputAction @TestTakeDamage => m_Wrapper.m_Gameplay_TestTakeDamage;
        public InputAction @TestKillEnemy => m_Wrapper.m_Gameplay_TestKillEnemy;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Kill.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKill;
                @Kill.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKill;
                @Kill.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKill;
                @TestTakeDamage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTestTakeDamage;
                @TestTakeDamage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTestTakeDamage;
                @TestTakeDamage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTestTakeDamage;
                @TestKillEnemy.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTestKillEnemy;
                @TestKillEnemy.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTestKillEnemy;
                @TestKillEnemy.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTestKillEnemy;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Kill.started += instance.OnKill;
                @Kill.performed += instance.OnKill;
                @Kill.canceled += instance.OnKill;
                @TestTakeDamage.started += instance.OnTestTakeDamage;
                @TestTakeDamage.performed += instance.OnTestTakeDamage;
                @TestTakeDamage.canceled += instance.OnTestTakeDamage;
                @TestKillEnemy.started += instance.OnTestKillEnemy;
                @TestKillEnemy.performed += instance.OnTestKillEnemy;
                @TestKillEnemy.canceled += instance.OnTestKillEnemy;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnKill(InputAction.CallbackContext context);
        void OnTestTakeDamage(InputAction.CallbackContext context);
        void OnTestKillEnemy(InputAction.CallbackContext context);
    }
}
