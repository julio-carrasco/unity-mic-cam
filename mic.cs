using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mic : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isRecording = false;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for input to start/stop recording
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isRecording)
            {
                StartRecording();
            }
            else
            {
                StopRecordingAndPlay();
            }
        }

    }

    void StartRecording()
    {
        // Start recording from the microphone
        audioSource.Stop();
        audioSource.clip = Microphone.Start(null, false, 10, 44100);
        isRecording = true;
    }

    void StopRecordingAndPlay()
    {
        // Stop recording from the microphone
        Microphone.End(null);

        // Play the recorded audio
        audioSource.Play();

        isRecording = false;
    }
}