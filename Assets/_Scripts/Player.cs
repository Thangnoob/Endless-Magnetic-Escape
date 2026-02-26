using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public MagneticType magneticType = MagneticType.North;

    private Rigidbody2D rb;

    [Header("Switch")]
    [SerializeField] private float cooldown = 0.2f;

    private float lastSwitch;


    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Example input handling for switching magnetic type
        if (GameInput.Instance.IsSwitchActionPressed() && Time.time - lastSwitch > cooldown)
        {
            SwitchPolarity();
            transform.Rotate(0, 0, 180f); // Rotate the player to visually indicate polarity change
            lastSwitch = Time.time;
        }
    }

    private void SwitchPolarity()
    {
        if (magneticType == MagneticType.North)
        {
            magneticType = MagneticType.South;
        }
        else
        {
            magneticType = MagneticType.North;
        }

        Debug.Log("Switched polarity to: " + magneticType);
    }

    public void ApplyForce(Vector2 force)
    {
        rb.AddForce(force);
    }
}
