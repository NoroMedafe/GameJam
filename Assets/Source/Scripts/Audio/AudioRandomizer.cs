using UnityEngine;
using System;

[Serializable]
public class AudioRandomizer
{
    [SerializeField] public AudioClip[] _clips;

    public AudioRandomizer(AudioClip[] clips)
    {
        _clips = clips;
    }

    public AudioClip PickRandom()
    {
        return _clips[UnityEngine.Random.Range(0, _clips.Length)];
    }
}