using System.Collections;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody2D RB2D { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float DashSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float FallSpeed { get; private set; }
    [field: SerializeField] public float MaxJumpTime { get; private set; }
    // [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
    [field: SerializeField] public float MaxReduction { get; private set; }
    [field: SerializeField] public float ReductionRate { get; private set; }
    //[field: SerializeField] public float RecoverySpeed { get; private set; }
    public Vector2 FacingDirection { get; set; }
    public Vector3 OriginalScale { get; private set; }
    [field: SerializeField] public bool isground = false;
    [field: SerializeField] public LayerMask groundLayer; // Layer yang digunakan untuk deteksi tanah
    [field: SerializeField] public Transform groundCheckPosition; // Posisi pemain untuk deteksi tanah
    [field: SerializeField] public float groundCheckRadius = 0.1f; // Radius deteksi tanah

    private void Start()
    {

        OriginalScale = transform.localScale; // Simpan skala asli pemain
        SwitchState(new PlayerLocoState(this));
    }

    public bool IsGrounded()
    {
        // Menjalankan overlap circle untuk mendeteksi objek yang berada di layer groundLayer
        // dengan radius groundCheckRadius di posisi groundCheckPosition
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPosition.position, groundCheckRadius, groundLayer);
        isground = true;
        // Jika terdapat setidaknya satu collider yang terdeteksi, berarti pemain menyentuh tanah
        return colliders.Length > 0;
    }

    public bool IsMoving()
    {
        // Implementasi logika untuk menentukan apakah pemain sedang bergerak
        return Mathf.Abs(InputReader.MovementValue.x) > 0;
    }
    public IEnumerator InstantRecoverScale(float recoverySpeed)
    {
        // Proses pemulihan skala secara langsung
        while (transform.localScale != OriginalScale)
        {
            // Interpolasi pemulihan skala
            transform.localScale = Vector3.Lerp(transform.localScale, OriginalScale, recoverySpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator SlowRecoverScale(float recoverySpeed)
    {
        // Proses pemulihan skala secara perlahan
        while (transform.localScale != OriginalScale)
        {
            // Interpolasi pemulihan skala
            transform.localScale = Vector3.Lerp(transform.localScale, OriginalScale, recoverySpeed * Time.deltaTime);
            yield return null;
        }
    }

}