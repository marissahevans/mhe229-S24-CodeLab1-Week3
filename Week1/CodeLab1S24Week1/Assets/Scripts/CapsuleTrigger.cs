using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTrigger : MonoBehaviour
{
    public int pointsPerCollectable = 25;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            GameManager.instance.score += pointsPerCollectable;
            Destroy(other.gameObject);
        }
        

    }

 
}
