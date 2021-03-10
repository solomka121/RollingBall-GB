using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int amount;
    public bool IsPushing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider triggerEvent)
    {
        if (IsPushing)
        {
            transform.position += new Vector3( 0 , 0, amount);
        }

    }
}
