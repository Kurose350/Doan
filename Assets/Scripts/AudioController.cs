using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource bossBattle;
    public AudioSource enemyExplosion;
    public AudioSource itemCollected;

    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    public void PlayEnemyExplosion()
    {
        enemyExplosion.Play();
    }

    public void PlayItemCollected()
    {
        itemCollected.Play();
    }

    public void FadeOutLevelMusic()
    {
        StartCoroutine("FadeOutLevelMusicCoroutine");
    }

    private IEnumerator FadeOutLevelMusicCoroutine()
    {
        float delta = 2;
        while (delta > 0)
        {
            delta -= Time.deltaTime;
            levelMusic.volume = delta / 2;
            yield return null;
        }

        yield return null;
    }

    public void PlayDragonBattleMusic()
    {
        bossBattle.Play();
    }

    public void LowerBattleMusic(float pitch)
    {
        if (bossBattle.isPlaying)
        {
            bossBattle.volume = 0.35f;
            bossBattle.pitch = pitch;
        }
    }
    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}
