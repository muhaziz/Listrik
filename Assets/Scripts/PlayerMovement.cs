using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputReader inputReader;
    private Rigidbody2D rb;
    private TrailRenderer tr;
    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing = false;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();

        inputReader.JumpEvent += Jump;
        inputReader.DashEvent += Dash;
    }

    private void OnEnable()
    {
        inputReader.enabled = true;
    }

    private void OnDisable()
    {
        inputReader.enabled = false;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    private void Dash()
    {
        if (canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(inputReader.MovementValue.x * speed, rb.velocity.y);
            Flip();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && inputReader.MovementValue.x < 0f || !isFacingRight && inputReader.MovementValue.x > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
