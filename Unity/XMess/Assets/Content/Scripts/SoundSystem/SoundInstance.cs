using UnityEngine;

public class SoundInstance : MonoBehaviour
{
    public AudioSource audioSouce;

    private void FixedUpdate()
    {
        if (!audioSouce.isPlaying)
            Destroy(gameObject);
    }
}