using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotionEvent : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject glow_R;
    public GameObject description_R;
    RaycastHit hit;

    public void HoverOver_R()
    {
        glow_R.SetActive(true);
        description_R.SetActive(true);
    }

    public void HoverEnd()
    {
        glow_R.SetActive(false);
        description_R.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        glow_R.SetActive(false);
        description_R.SetActive(false);
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
