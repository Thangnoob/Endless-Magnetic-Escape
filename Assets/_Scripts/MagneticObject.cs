using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    public MagneticType magneticType;
    public float magneticForce = 10f;
    public float radius = 5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerLine"))
        {
            Vector2 direction = (Player.Instance.transform.position - transform.position).normalized;

            if (Player.Instance.magneticType == magneticType)
            {
                Player.Instance.ApplyForce(direction * magneticForce);
            }
            else
            {
                Player.Instance.ApplyForce(-direction * magneticForce);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }   
}
