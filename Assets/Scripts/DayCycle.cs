using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    private Transform transform;
    public float cycleSpeed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }
    
    void FixedUpdate()
    {
        transform.Rotate(0, 0, cycleSpeed);
    }
}
