using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    [SerializeField] Footsteper m_footsteper;

    public void OnFootstep()
    {
        m_footsteper.OnFootstep();
    }
}
