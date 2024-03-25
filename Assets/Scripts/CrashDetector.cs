using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//put on player to detect crashes with the mountain surface
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip  crashSFX;
    bool alreadyCrashed = false;

    //On the first time the player crashes (head collider) with slope, play V/SFx and restart
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "RestartZone" && !alreadyCrashed)
        {
            alreadyCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
