using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public MagneticType magneticType = MagneticType.North;

    private Rigidbody2D rb;

    [Header("Switch")]
    [SerializeField] private float cooldown = 0.2f;
    private float lastSwitch;

    [Header("Rotation Setup")]
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float angleOffset = 90f; 

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandlePolaritySwitch();

        HandleRotationByJoystick();
    }

    private void HandlePolaritySwitch()
    {
        if (GameInput.Instance.IsSwitchActionPressed() && Time.time - lastSwitch > cooldown)
        {
            SwitchPolarity();
            transform.Rotate(0, 0, 180f); 
            lastSwitch = Time.time;
        }
    }

    private void SwitchPolarity()
    {
        if (magneticType == MagneticType.North)
            magneticType = MagneticType.South;
        else
            magneticType = MagneticType.North;

        Debug.Log("Switched polarity to: " + magneticType);
    }

    public void ApplyForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    private void HandleRotationByJoystick()
    {
        Vector2 moveDir = GameInput.Instance.GetMovementVectorNormalized();

        // make sure to only rotate when there's some input
        if (moveDir != Vector2.zero)
        {
            //Atan2 helps convert a vector (x,y) to an angle in Radians, then * Radians to Degrees
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;

            // Điều chỉnh góc cho đúng hướng ảnh của bạn
            // Fix rotaion offset if your sprite faces right (0 degrees) by default, you might need to subtract 90 degrees to align it correctly
            angle -= angleOffset;

            //Ratate the player smoothly towards the target angle
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
