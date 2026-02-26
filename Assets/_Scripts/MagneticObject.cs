using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    public MagneticType magneticType;
    public float magneticForce = 10f;
    public float radius = 5f;

    private void FixedUpdate()
    {
        if (Player.Instance == null) return;
        CheckDistanceAndAddForce();
    }

    private void CheckDistanceAndAddForce()
    {
        float distance = Vector2.Distance(transform.position, Player.Instance.transform.position);

        if (distance <= radius)
        {
            Vector2 direction = Player.Instance.transform.position - transform.position;
            direction.Normalize();

            if (Player.Instance.magneticType == magneticType)
            {
                // repel
                Player.Instance.ApplyForce(direction * magneticForce);
                Debug.Log("Repelling player with force: " + (direction * magneticForce));   
            }
            else
            {
                // attract 
                Player.Instance.ApplyForce(-direction * magneticForce);
                Debug.Log("Attracting player with force: " + (-direction * magneticForce));
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }   
}
