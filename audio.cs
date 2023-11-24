using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    private AudioSource audio;
    GameObject eatingObject;

    void Start()
    {
        eatingObject = GameObject.FindGameObjectWithTag("eating_audio");
        if (eatingObject != null)
        {
            audio = eatingObject.GetComponent<AudioSource>();
        }

    }

    // This method is called when a collision occurs
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag (optional)
        if (collision.gameObject.CompareTag("araña"))
        {
            // Play the audio clip
            audio.Play();
            Debug.Log("El audio ha sonado");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Use this if colliders are marked as triggers
        if (other.gameObject.CompareTag("araña"))
        {
            audio.Play();
            Debug.Log("El audio ha sonado");
        }
    }
}
