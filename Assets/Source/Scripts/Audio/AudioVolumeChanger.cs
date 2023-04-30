using System.Collections;
using UnityEngine;

public class AudioVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _source1;
    [SerializeField] private AudioSource _source2;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            From1To2();
        }
    }

    public void From1To2()
    {
        _source2.Play();
        StartCoroutine(ChangeVolume(_source1, 0.8f, 0, 1f));
        StartCoroutine(ChangeVolume(_source2, 0, 0.8f, 1f));
    }

    private IEnumerator ChangeVolume(AudioSource audioSource, float from, float to, float duration)
    {
        float volumeDelta = to - from;
        float elapsedTime = 0;

        while (audioSource.volume != to)
        {
            audioSource.volume = from + volumeDelta * (elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (to == 0)
        {
            audioSource.Stop();
        }
    }
}
