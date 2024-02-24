using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    public enum SoundType
    {
        Attack = 1,
        Damage = 2,
    }
    public void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(SoundType sound)
    {
        switch (sound) 
        {
            //case SoundType.Attack: m_AudioSource.clip = m_Attack; break;
            //case SoundType.Damage 
        }
    }
}
