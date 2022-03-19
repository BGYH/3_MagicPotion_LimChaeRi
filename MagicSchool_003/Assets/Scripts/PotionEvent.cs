using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEvent : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider coll)
    {
        rb.AddForce(Vector3.up * 30.0f, ForceMode.Acceleration);
    }

    /* Update is called once per frame
    void Update()
    {
        
    }*/
}
