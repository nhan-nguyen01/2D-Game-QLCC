using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource FinishSound;
    void Start()
    {
        FinishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.name == "Player")
        {
            FinishSound.Play();
            CompleteLevel();
        }
    }
    private void CompleteLevel()
    {

    }
}
