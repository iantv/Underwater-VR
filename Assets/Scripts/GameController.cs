using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsVRMode;
    public GameObject Submarine;
    public int DirectionSpeed;
    private int rotationSpeed;
    [SerializeField]
    public int RotationSpeed;// { get => rotationSpeed; set => rotationSpeed = value; }
    public GameObject SpotLight;

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
            Vector3 rot = Vector3.zero;
            Vector3 hei = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.F))
            {
                SpotLight.SetActive(!SpotLight.active);
            }

            if (Input.GetKey(KeyCode.W))
            {
                force = Time.deltaTime * DirectionSpeed * Submarine.transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                force = -1 * Time.deltaTime * DirectionSpeed * Submarine.transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                force = -1 * Time.deltaTime * DirectionSpeed * Submarine.transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                force = Time.deltaTime * DirectionSpeed * Submarine.transform.right;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                rot.z += Time.deltaTime * RotationSpeed;
            }
            if (Input.GetKey(KeyCode.E)) 
            {
                rot.z -= Time.deltaTime * RotationSpeed;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (Submarine.transform.position.y < 46)
                    hei.y += Time.deltaTime * 3f;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                hei.y -= Time.deltaTime * 1f;
            }
            if (Input.GetKey(KeyCode.Mouse0))
                rot.y = Input.GetAxis("Mouse X") *2;
            if (Input.GetKey(KeyCode.Mouse1))
                rot.x = Input.GetAxis("Mouse Y");
            rb.AddForce(force);
            Submarine.transform.Rotate(rot);
            Submarine.transform.Translate(hei, Space.World);

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = Vector3.zero;
                Debug.Log("Stop submarine");
            }
        }
    }
}
