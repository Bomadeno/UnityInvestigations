using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderOfExecutionTest : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}
