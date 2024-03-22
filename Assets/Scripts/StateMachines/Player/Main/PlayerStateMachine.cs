using System.Collections;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody2D RB2D { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }

    //!Movement
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float DashPower { get; private set; }
    [field: SerializeField] public float DashCooldown { get; private set; }
    [field: SerializeField] public float DashTime { get; private set; }

    //!
    [SerializeField] public bool BisaDash = true;
    [SerializeField] public bool LagiDash = false;
    [SerializeField] public bool DashCoolRun = false;
    [SerializeField] public bool LagiHeal = false;

    [SerializeField] public bool facingRight = true;
    [SerializeField] private float flipRotationY = 180f;


    //! Jump System
    [field: SerializeField] public float JumpForce { get; private set; }


    // [field: SerializeField] public float heal { get; private set; }
    // //! Shrink System
    public Vector3 OriginalScale { get; private set; }
    [field: SerializeField] public float MaxReduction { get; private set; }
    [field: SerializeField] public float ReductionRate { get; private set; }


    //! Check Ground
    [field: SerializeField] public bool isground = false;
    [field: SerializeField] public LayerMask groundLayer; // Layer yang digunakan untuk deteksi tanah
    [field: SerializeField] public Transform groundCheckPosition; // Posisi pemain untuk deteksi tanah
    [field: SerializeField] public float groundCheckRadius = 0.1f; // Radius deteksi tanah


    private void Start()
    {
        OriginalScale = transform.localScale;
        SwitchState(new PlayerLocoState(this));
    }

    public bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPosition.position, groundCheckRadius, groundLayer);
        return colliders.Length > 0;
    }

    public void StartDashCooldown()
    {
        if (!DashCoolRun) // Pastikan cooldown tidak sedang berjalan
        {
            StartCoroutine(CooldownCoroutine());
        }
    }

    private IEnumerator CooldownCoroutine()
    {

        yield return new WaitForSeconds(DashCooldown);
        BisaDash = true; // Aktifkan kembali kemampuan dash setelah cooldown selesai
        DashCoolRun = false; // Setel kembali ke false setelah cooldown selesai
    }

    public bool IsMoving()
    {
        return Mathf.Abs(InputReader.MovementValue.x) > 0;
    }

    public void FlipCharacter(float moveInput)
    {
        if ((moveInput > 0 && !facingRight) || (moveInput < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 newRotation = transform.eulerAngles;
            newRotation.y += flipRotationY; // Tambahkan rotasi flip
            transform.eulerAngles = newRotation;
        }
    }

}