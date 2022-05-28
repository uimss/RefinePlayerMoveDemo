using UnityEngine;

public class PlayerFootsteperV8 : Footsteper
{
    [SerializeField] AudioSource m_audioSourceLeft;
    [SerializeField] AudioSource m_audioSourceRight;

    bool m_isNextLeft = false;

    public override void OnFootstep()
    {
        if (m_isNextLeft)
        {
            m_audioSourceLeft.Play();
            m_isNextLeft = false;
        }
        else
        {
            m_audioSourceRight.Play();
            m_isNextLeft = true;
        }
    }

}
