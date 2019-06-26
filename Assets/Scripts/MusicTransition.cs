using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicTransition : MonoBehaviour
{
    public AudioMixerSnapshot AdulthoodMusic;
    public AudioMixerSnapshot ChildhoodMusic;
    public AudioMixerSnapshot OldAgeMusic;
    public float bpm = 128;


    private float m_Transition;
    private float m_QuarterNote;


    // Start is called before the first frame update
    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_Transition = m_QuarterNote;

    }

    // Update is called once per frame
    void OnTriggerEnterChildhood(Collider other)
    {
        if (other.CompareTag("ChidhoodZone"))
        {
        ChildhoodMusic.TransitionTo(m_Transition);
        }
    }
    void OnTriggerEnterAdulthood(Collider other)
    {
        if (other.CompareTag("AdulthoodZone"))
        {
        AdulthoodMusic.TransitionTo(m_Transition);
        }
    }
    void OnTriggerEnterOldage(Collider other)
    {
        if (other.CompareTag("OldageZone"))
        {
            OldAgeMusic.TransitionTo(m_Transition);
        }
    }
}
