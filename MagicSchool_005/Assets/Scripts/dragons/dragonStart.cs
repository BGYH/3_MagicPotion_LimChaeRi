using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonStart : MonoBehaviour
{
    public Transform startPot;
    public Transform endPot;
    //public float posSpeed = 1.0f;
    float startTime;
    float totalDistance;

    public Vector3 minScale;
    public Vector3 maxScale;
    public float speed = 3f;
    public float duration = 5f;

    // Start is called before the first frame update
    public IEnumerator Start()
    {
        startTime = Time.deltaTime;
        totalDistance = Vector3.Distance(startPot.position, endPot.position);
        
        minScale = transform.localScale = new Vector3(0, 0, 0);
        yield return RepeatLerp(startPot.position, endPot.position, 3.0f, minScale, maxScale, duration);
        Debug.Log("dragonStart");
    }

    // Update is called once per frame
    void Update()
    {
        float currentDutation = (Time.time - startTime) * speed;
        float journeyFraction = currentDutation / totalDistance;
        this.transform.position = Vector3.Lerp(startPot.position, endPot.position, journeyFraction);
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time, Vector3 c, Vector3 d, float duration)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(c, d, i);
            this.transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
