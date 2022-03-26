using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotEvent : MonoBehaviour
{
    public GameObject Potion_G;
    public GameObject Potion_B;
    public GameObject Potion_R;
    private Collider coll;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == Potion_G)
        {
            Potion_G.SetActive(false);
        }

        if (coll.gameObject == Potion_B)
        {
            Potion_B.SetActive(false);
        }

        if (coll.gameObject == Potion_R)
        {
            Potion_R.SetActive(false);
        }
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
