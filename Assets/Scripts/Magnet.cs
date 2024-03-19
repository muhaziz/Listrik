using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float maxAttractionForce = 20f; // Besarnya gaya tarik magnet saat jarak minimum
    [SerializeField] private float minAttractionDistance = 1f; // Jarak minimum di mana gaya magnet maksimum tercapai
    [SerializeField] private float attractionDistance = 5f; // Jarak maksimum di mana gaya tarik masih berlaku

    private void Update()
    {
        // Temukan semua pemain dalam radius magnet
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, attractionDistance, LayerMask.GetMask("Player"));

        foreach (Collider2D playerCollider in players)
        {
            Rigidbody2D playerRB = playerCollider.GetComponent<Rigidbody2D>();

            if (playerRB != null)
            {
                // Hitung jarak antara pemain dan magnet
                float distance = Vector2.Distance(playerRB.position, (Vector2)transform.position);

                // Interpolasi linier untuk menentukan gaya tarik berdasarkan jarak
                float normalizedDistance = Mathf.Clamp01((distance - minAttractionDistance) / (attractionDistance - minAttractionDistance));
                float attractionForce = Mathf.Lerp(0f, maxAttractionForce, normalizedDistance);

                // Hitung vektor arah dari pemain ke magnet
                Vector2 direction = ((Vector2)transform.position) - playerRB.position;

                // Normalisasi vektor arah
                direction.Normalize();

                // Terapkan gaya tarik pada pemain
                playerRB.AddForce(direction * attractionForce * Time.deltaTime);
            }
        }
    }

    // Tampilkan gizmos untuk mewakili jangkauan magnet
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attractionDistance);
    }
}
