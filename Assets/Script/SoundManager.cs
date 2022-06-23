using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip FireBall;
    public AudioClip MeleeAttack;
    public AudioClip SwordAttack;
    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip Explode;
    public AudioClip PickUp;
    private AudioSource audio;

    private void Awake() 
    {
        if (instance != null)
            Destroy(Lose);
        else
            instance = this;

        audio = GetComponent<AudioSource>();
    }

    public void FireballSfx()
    {
        audio.PlayOneShot(FireBall);
    }

    public void MeleeSfx()
    {
        audio.PlayOneShot(MeleeAttack);
    }

    public void ExplodeSfx()
    {
        audio.PlayOneShot(Explode);
    }

    public void WinSfx()
    {
        audio.PlayOneShot(Win);
    }

    public void LoseSfx()
    {
        audio.PlayOneShot(Lose);
    }

    public void SwordSfx()
    {
        audio.PlayOneShot(SwordAttack);
    }

    public void PickUpSfx()
    {
        audio.PlayOneShot(PickUp);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
