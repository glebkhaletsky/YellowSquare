using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField]
    AudioSource MyFX;
    [SerializeField]
    AudioClip endFX;

    public bool on;
    void Start()
    {
        on = FindObjectOfType<PlayerScript>().PSDead;
    }
    void Update()
    {
        if (on == true)
        {
            MyFX.PlayOneShot(endFX);
        }
    }
}
