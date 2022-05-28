using UnityEngine;

public class PlayerFootsteperV9 : Footsteper
{
    [SerializeField] AudioSource m_audioSourceLeft;
    [SerializeField] AudioSource m_audioSourceRight;
    [SerializeField] ParticleSystem m_gas;

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
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.position = transform.localPosition;
        emitParams.applyShapeToPosition = true;
        m_gas.Emit(emitParams, 1);
    }

}
