using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    public enum Polarity { Positive, Negative }
    public Polarity polarity;

    [SerializeField] private float magneticForce = 10f;

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f); // Radius interaksi magnet

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player")) // Cek jika yang terdeteksi adalah pemain
            {
                Rigidbody2D playerRB = collider.GetComponent<Rigidbody2D>();
                if (playerRB != null)
                {
                    Vector2 direction = ((Vector2)transform.position - playerRB.position).normalized;
                    Vector2 force = direction * magneticForce;

                    if ((polarity == Polarity.Positive && collider.GetComponent<PlayerStateMachine>().IsNegative) ||
                        (polarity == Polarity.Negative && !collider.GetComponent<PlayerStateMachine>().IsNegative))
                    {
                        // Tarik pemain ke arah magnet
                        playerRB.AddForce(force);
                    }
                    else
                    {
                        // Tolak pemain dari magnet
                        playerRB.AddForce(-force);
                    }
                }
            }
        }
    }
}
