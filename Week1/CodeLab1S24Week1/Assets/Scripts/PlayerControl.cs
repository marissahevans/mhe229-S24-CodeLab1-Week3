using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float maxVelo = 40;

    public float forceAmount = 100;

    private Rigidbody rb;

    public static PlayerControl instance;
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forceAmount * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(forceAmount * Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(forceAmount * Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(forceAmount * Vector3.right);
        }
        
        // use normalization and magnitude to maintain maxVelo
        if (rb.velocity.magnitude > maxVelo)
        {
            Vector3 newVelocity = rb.velocity.normalized;
            newVelocity *= maxVelo;
            rb.velocity = newVelocity;
        }
    }
}
