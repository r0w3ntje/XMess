using Systems.Singleton;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Sound Instance Prefab")]
    public GameObject soundInstance;

    [Header("Sounds")]
    public AudioClip monster;

    public void PlayMonsterSound()
    {
        PlaySound(monster);
    }

    public void PlaySound(AudioClip _ac)
    {
        GameObject asi = Instantiate(soundInstance);
        asi.transform.SetParent(transform);

        asi.GetComponent<SoundInstance>().audioSouce.clip = _ac;
        asi.GetComponent<SoundInstance>().audioSouce.Play();
    }
}