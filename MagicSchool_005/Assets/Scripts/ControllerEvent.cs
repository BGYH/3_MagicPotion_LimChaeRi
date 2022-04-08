using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerEvent : MonoBehaviour
{
    public XRController controller = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aButton();
    }

    public void aButton()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
        {
            if (AButton == true)
            {
                Debug.Log("select");
            }
        }
    }
}
