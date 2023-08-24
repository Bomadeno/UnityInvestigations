using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderOfExecutionTest : MonoBehaviour
{
    [SerializeField] private OrderOfExecutionBestPractice okFunctionDemo;
    [SerializeField] private  OrderOfExecutionBestPractice faultyFunctionDemo;

    void Start()
    {
        okFunctionDemo.DoSomething();
        faultyFunctionDemo.DoSomething();
    }
}
