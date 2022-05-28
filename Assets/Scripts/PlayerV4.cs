using UnityEngine;

public class PlayerV4 : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;

    Rigidbody2D m_rigidBody;
    [SerializeField] GameObject m_playerSprite;
    Animator m_animator;
    Vector2 m_velocity = Vector2.zero;
    PlayerLookDirection m_lookDir;
    bool m_isMove = false;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = m_playerSprite.GetComponent<Animator>();
    }

    void Update()
    {
        var move = GetInputMove();
        var isMove = false;
        var lookDir = m_lookDir;

        if (move.x != 0)
        {
            isMove = true;
            m_velocity = new Vector2(move.x * m_speed, 0);
            if (move.x > 0)
            {
                lookDir = PlayerLookDirection.Right;
            }
            else
            {
                lookDir = PlayerLookDirection.Left;
            }
        }
        else if (move.y != 0)
        {
            isMove = true;
            m_velocity = new Vector2(0, move.y * m_speed);
            if (move.y > 0)
            {
                lookDir = PlayerLookDirection.Top;
            }
            else
            {
                lookDir = PlayerLookDirection.Bottom;
            }
        }
        else
        {
            m_velocity = Vector2.zero;
        }

        if (isMove != m_isMove || lookDir != m_lookDir)
        {
            var stateName = isMove ? "Walk" : "Idle";

            switch (lookDir)
            {
                case PlayerLookDirection.Bottom:
                    m_animator.Play(stateName + "_B");
                    break;
                case PlayerLookDirection.Top:
                    m_animator.Play(stateName + "_T");
                    break;
                case PlayerLookDirection.Left:
                    m_animator.Play(stateName + "_L");
                    break;
                case PlayerLookDirection.Right:
                    m_animator.Play(stateName + "_R");
                    break;
            }
        }

        m_isMove = isMove;
        m_lookDir = lookDir;
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

    enum PlayerLookDirection
    {
        Top,
        Bottom,
        Left,
        Right
    }
}
