using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsVRMode;
    public GameObject Submarine;
    public int Speed;

    void Start()
    {
        
    }

    void Update()
    {
        if (IsVRMode)
        {
            // Use VR Controllers
        }
        else
        {
            Rigidbody rb = Submarine.GetComponent<Rigidbody>();
            Vector3 force = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                force = Time.deltaTime * Speed * Submarine.transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                force = -1 * Time.deltaTime * Speed * Submarine.transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                force = -1 * Time.deltaTime * Speed * Submarine.transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                force = Time.deltaTime * Speed * Submarine.transform.right;
            }

            rb.AddForce(force);

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = Vector3.zero;
                Debug.Log("Stop submarine");
            }
        }
    }
}
