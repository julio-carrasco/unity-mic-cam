using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_player : MonoBehaviour
{
    private GameObject tv;

    private WebCamTexture webcamTexture;

    void Start()
    {
        // Check if the device has a camera
        if (WebCamTexture.devices.Length > 0)
        {
            // Use the first available camera
            webcamTexture = new WebCamTexture(WebCamTexture.devices[0].name);
            webcamTexture.Play();
        }
        else
        {
            Debug.LogError("No camera found on this device.");
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartRecording();
        }

        
        if (Input.GetKeyUp(KeyCode.S))
        {
            StopRecordingAndPlay();
        }
    }

    void StartRecording()
    {
       
        tv.GetComponent<Renderer>().material.mainTexture = webcamTexture;
    }

    void StopRecordingAndPlay()
    {
       
        tv.GetComponent<Renderer>().material.mainTexture = null;
    }

    void OnDestroy()
    {
        // Stop the webcam texture when the script is destroyed
        if (webcamTexture != null)
        {
            webcamTexture.Stop();
        }
    }
}
