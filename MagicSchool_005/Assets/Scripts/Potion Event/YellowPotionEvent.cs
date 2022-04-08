using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPotionEvent : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Glow_Y;
    public GameObject descripion_Y;
    RaycastHit hit;

    public void HoverOver()
    {
        Glow_Y.SetActive(true);
        descripion_Y.SetActive(true);
    }

    public void HoverEnd()
    {
        Glow_Y.SetActive(false);
        descripion_Y.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        Glow_Y.SetActive(false);
        descripion_Y.SetActive(false);
    }

    private void OnTriggerStay(Collider coll)
    {
        //rb.AddForce(Vector3.up * 4f, ForceMode.Acceleration);

    }

    /* Update is called once per frame
    void Update()
    {
        
    }*/
}
