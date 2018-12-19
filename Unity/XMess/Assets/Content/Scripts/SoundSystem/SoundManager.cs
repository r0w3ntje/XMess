using Systems.Singleton;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Sound Instance Prefab")]
    public GameObject soundInstance;

    [Header("Demon Sounds")]
    public AudioClip spawnDemonScreetch;    
    public AudioClip deathDemonSplat;
    [Header("Gun Sounds")]
    public AudioClip gunShot;
    [Header("Player Sounds")]
    public AudioClip playerDeath;
    public AudioClip playerJump;

    public void PlayDemonScreetch()
    {
        PlaySound(spawnDemonScreetch);
    }

    public void PlayDemonDeath()
    {
        PlaySound(deathDemonSplat);
    }

    public void PlayGunShot()
    {
        PlaySound(gunShot);
    }

    public void PlayPlayerDeath()
    {
        PlaySound(playerDeath);
    }

    public void PlayPlayerJump()
    {
        PlaySound(playerJump);
    }

    public void PlaySound(AudioClip _ac)
    {
        GameObject asi = Instantiate(soundInstance);
        asi.transform.SetParent(transform);

        asi.GetComponent<SoundInstance>().audioSouce.clip = _ac;
        asi.GetComponent<SoundInstance>().audioSouce.Play();
    }
}