using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipesLeak : MonoBehaviour
{
    public GameObject leak;

    private GameObject pipes;

    void Start()
    {
        GenerateRandomLeak();
    }

    void Update()
    {
        
    }

    void GenerateRandomLeak()
    {
        foreach (Transform child in transform)
        {
            GameObject t = Instantiate(leak, child.position, Quaternion.Euler(-90, 0, 0), child);
        }
    }
}
