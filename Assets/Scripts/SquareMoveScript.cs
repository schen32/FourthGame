using UnityEngine;
using UnityEngine.InputSystem;

public class SquareMoveScript : MonoBehaviour
{
    public float m_moveSpeed = 5f;
    Vector2 m_moveInput;

    SpriteRenderer m_spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(m_moveInput.x, m_moveInput.y, 0);

        if (movement.magnitude > 0)
        {
            m_spriteRenderer.color = Color.red;
        }
        else
        {
            m_spriteRenderer.color = Color.white;
        }

        transform.position += movement * m_moveSpeed * Time.deltaTime;
    }
    void OnMove(InputValue value)
    {
        m_moveInput = value.Get<Vector2>();
    }
}
