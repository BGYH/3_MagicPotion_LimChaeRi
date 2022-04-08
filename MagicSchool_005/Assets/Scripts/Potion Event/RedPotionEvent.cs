using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotionEvent : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject glow_R;
    public GameObject descripion_R;
    RaycastHit hit;

    public void HoverOver()
    {
        glow_R.SetActive(true);
        descripion_R.SetActive(true);
    }

    public void HoverEnd()
    {
        glow_R.SetActive(false);
        descripion_R.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        glow_R.SetActive(false);
        descripion_R.SetActive(false);
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
