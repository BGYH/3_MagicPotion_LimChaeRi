using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPotionEvent : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject glow_G;
    public GameObject descripion_G;
    RaycastHit hit;

    public void HoverOver_G()
    {
        glow_G.SetActive(true);
        descripion_G.SetActive(true);
    }

    public void HoverEnd()
    {
        glow_G.SetActive(false);
        descripion_G.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        glow_G.SetActive(false);
        descripion_G.SetActive(false);
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
