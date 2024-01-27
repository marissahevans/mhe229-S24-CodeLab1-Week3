using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera CameraOverhead;
    public Camera CameraSide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraOverhead.enabled = false;
            CameraSide.enabled = true;
        }
    }
}
