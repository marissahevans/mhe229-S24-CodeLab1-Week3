using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTrigger : MonoBehaviour
{
    public int pointsPerCollectable = 100;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            GameManager.instance.Score += (int)(pointsPerCollectable / GameManager.instance.timer);
            //Debug.Log("pts pos: " + pointsPerCollectable);
            //Debug.Log("time: " + GameManager.instance.timer);
            //Debug.Log("points: " + (pointsPerCollectable / GameManager.instance.timer));
            GameManager.instance.timer = 0;
            Destroy(other.gameObject);
        }
        

    }

 
}
