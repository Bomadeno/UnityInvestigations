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

        child = new GameObject("Child");
        child.transform.parent = transform;
        initialized = true;
    }

    [ContextMenu("Do Something")]
    internal void DoSomething()
    {
        if(!enableFaultyFunctionBehavior)
            InitializeIfNeeded();

        TestIsItOk();
    }

    private void TestIsItOk()
    {
        if (child == null)
        {
            Debug.Log($"{gameObject.name} logic is <color=#FF0000>broken</color>", this);
        }
        else
        {
            Debug.Log($"{gameObject.name} logic is <color=#00FF00>ok</color>", this);
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
