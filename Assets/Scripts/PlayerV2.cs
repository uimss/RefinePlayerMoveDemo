using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;

    Rigidbody2D m_rigidBody;
    Vector2 m_velocity;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var move = GetInputMove();
        if (move.x != 0)
        {
            m_velocity = new Vector2(move.x * m_speed, 0);
        }
        else if (move.y != 0)
        {
            m_velocity = new Vector2(0, move.y * m_speed);
        }
        else
        {
            m_velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        m_rigidBody.velocity = m_velocity;
    }

    (float x, float y) GetInputMove()
    {
        return (
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }
}
