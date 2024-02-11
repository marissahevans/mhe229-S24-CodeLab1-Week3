using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SceneTrig"))
        {
            GameManager.instance.sceneTrig += 1;
        }
        

    }
}
