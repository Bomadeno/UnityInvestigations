using System.Collections.Generic;
using UnityEngine;

public class OrderOfExecutionBestPractice : MonoBehaviour
{
    [SerializeField] private bool enableFaultyAwakeBehavior;
    [SerializeField] private bool enableFaultyFunctionBehavior;
    private bool initialized;
    private GameObject child;
    
    private void Awake()
    {
        if (!initialized && !enableFaultyAwakeBehavior)
        {
            InitializeIfNeeded();
        }
        
        TestIsItOk();
    }

    void InitializeIfNeeded()
    {
        if (initialized)
            return;

        child = Instantiate(gameObject, transform);
    }

    [ContextMenu("Do Something")]
    void DoSomething()
    {
        if(!enableFaultyFunctionBehavior)
            InitializeIfNeeded();

        TestIsItOk();
    }

    private void TestIsItOk()
    {
        if (child == null)
        {
            Debug.Log("it's broken");
        }
        else
        {
            Debug.Log("it's ok");
        }
    }

    [ContextMenu("Do Reset")]
    private void Reset()
    {
        foreach (Transform kid in transform)
        {
            if(Application.isPlaying)
            {
                Destroy(kid.gameObject);
            }
            else
            {
                DestroyImmediate(kid.gameObject);
            }
        }

        child = null;

    }
}
