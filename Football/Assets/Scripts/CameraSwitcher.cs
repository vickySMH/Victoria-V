using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<Camera> cameras;
    private int currentCameraIndex;

    private void Start()
    {
        // Deactivate all cameras except the first one
        for (int i = 1; i < cameras.Count; i++)
        {
            cameras[i].enabled = false;
        }

        if (cameras.Count > 0)
        {
            cameras[0].enabled = true;
            currentCameraIndex = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // Deactivate the current camera
        cameras[currentCameraIndex].enabled = false;

        // Increment the camera index and wrap around if necessary
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;

        // Activate the next camera
        cameras[currentCameraIndex].enabled = true;
    }
}