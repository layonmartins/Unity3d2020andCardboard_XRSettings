using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsGrab : MonoBehaviour
{
    public bool canGrab;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            canGrab = true;
        }
    }

    // Update is called once per frame
    public void OnTriggerExit(Collider other)
    {
        canGrab = false;
    }
}
