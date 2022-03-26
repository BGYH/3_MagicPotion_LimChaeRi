using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotionEvent : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject glow_B;
    public GameObject descripion_B;
    RaycastHit hit;

    public void HoverOver_B()
    {
        glow_B.SetActive(true);
        descripion_B.SetActive(true);
    }

    public void HoverEnd()
    {
        glow_B.SetActive(false);
        descripion_B.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        glow_B.SetActive(false);
        descripion_B.SetActive(false);
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
