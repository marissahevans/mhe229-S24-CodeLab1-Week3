using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTrigger : MonoBehaviour
{
    public float score;
    public float pointsPerCollectable = 25;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            score += pointsPerCollectable;
            Destroy(other.gameObject);
        }
        

    }

 
}
