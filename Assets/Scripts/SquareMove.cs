using UnityEngine;
using UnityEngine.InputSystem;

public class SquareMove : MonoBehaviour
{
    public float m_moveSpeed;
    public float m_jumpForce;

    public Transform m_groundCheck;
    public float m_groundCheckRadius;
    public LayerMask m_groundLayer;

    Vector2 m_moveInput;
    bool m_canJump;

    SpriteRenderer m_spriteRenderer;
    Rigidbody2D m_rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_moveSpeed = 5f;
        m_jumpForce = 5f;

        m_groundCheckRadius = 0.1f;

        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            m_spriteRenderer.color = Color.red;
            m_canJump = true;
        }
        else
        {
            m_spriteRenderer.color = Color.white;
            m_canJump = false;
        }
    }
    void FixedUpdate()
    {
        if (m_moveInput.x == 0)
        {
            m_rigidbody.linearVelocityX = 0;
        }
        else if (m_moveInput.x > 0)
        {
            m_rigidbody.linearVelocityX = m_moveSpeed;
        }
        else if (m_moveInput.x < 0)
        {
            m_rigidbody.linearVelocityX = -m_moveSpeed;
        }

        if (m_moveInput.y > 0 && m_canJump)
        {
            m_rigidbody.linearVelocityY = m_jumpForce;
        }
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(m_groundCheck.position, m_groundCheckRadius, m_groundLayer);
    }
    void OnMove(InputValue value)
    {
        m_moveInput = value.Get<Vector2>();
    }
}
