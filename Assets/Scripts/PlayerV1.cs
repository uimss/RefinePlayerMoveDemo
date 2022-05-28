using UnityEngine;

public class PlayerV1 : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;

    void Update()
    {
        var move = GetInputMove();
        Vector2 position = transform.position;
        if (move.x != 0)
        {
            position.x += move.x * m_speed;
        }
        else if (move.y != 0)
        {
            position.y += move.y * m_speed;
        }
        transform.position = position;
    }

    (float x, float y) GetInputMove()
    {
        return (
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }
}
