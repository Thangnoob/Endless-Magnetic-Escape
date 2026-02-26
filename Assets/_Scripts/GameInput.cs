using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private InputActions inputActions;

    private void Awake()
    {
        Instance = this;
        inputActions = new InputActions();
        inputActions.Enable();  

    }

    private void OnDestroy()
    {
        inputActions.Disable();
    }

    public bool IsSwitchActionPressed()
    {
        return inputActions.Player.SwitchPole.IsPressed();
    }
}
