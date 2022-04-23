using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Particle : MonoBehaviour
{
    //public bool playAura = true; //파티클 제어 bool
    public ParticleSystem particleObject; //파티클시스템
}

public class PotEvent : MonoBehaviour
{
    public GameObject Potion_B;
    public GameObject Potion_R;
    public GameObject Potion_G;
    public GameObject Potion_Y;

    public GameObject Cube;
    public GameObject Capsule1;
    public GameObject Cylinder;
    public GameObject Sphere;
    public GameObject Capsule2;
    public GameObject Cube2;

    public ParticleSystem Pongdang; //파티클시스템
    public ParticleSystem Bubble; //파티클시스템

    private Collider coll;
    private List<string> tagList = new List<string>();
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cube.SetActive(false);
        Capsule1.SetActive(false);
        Cylinder.SetActive(false);
        Sphere.SetActive(false);
        Capsule2.SetActive(false);
        Cube2.SetActive(false);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == Potion_B)
        {
            cnt += 1;
            Potion_B.SetActive(false);
            Pongdang.startColor = new Color(0, 50, 255);
            Pongdang.Play();
            tagList.Add("Blue");
        }

        if (coll.gameObject == Potion_R)
        {
            cnt += 1;
            Potion_R.SetActive(false);
            Pongdang.startColor = new Color(255, 0, 0);
            Pongdang.Play();
            tagList.Add("Red");
        }

        if (coll.gameObject == Potion_G)
        {
            cnt += 1;
            Potion_G.SetActive(false);
            Pongdang.startColor = new Color(0, 128, 0);
            Pongdang.Play();
            tagList.Add("Green");
        }

        if (coll.gameObject == Potion_Y)
        {
            cnt += 1;
            Potion_Y.SetActive(false);
            Pongdang.startColor = new Color(255, 215, 0);
            Pongdang.Play();
            tagList.Add("Yellow");
        }

        if (cnt == 2)
        {
            //Debug.Log("tagList : " + tagList[0] + ", " + tagList[1]);
            Invoke("DragonAppear", 2f);
        }
    }

    public void DragonAppear()
    {
        Debug.Log("tagList : " + tagList[0] + ", " + tagList[1]);
        Bubble.Play();

        if (tagList.Contains("Red") && tagList.Contains("Blue"))
        {
            StartCoroutine(cubeActive());
        }
        if (tagList.Contains("Red") && tagList.Contains("Green"))
        {
            StartCoroutine(capsule1Active());
        }
        if (tagList.Contains("Red") && tagList.Contains("Yellow"))
        {
            StartCoroutine(CylinderActive());
        }
        if (tagList.Contains("Blue") && tagList.Contains("Green"))
        {
            StartCoroutine(SphereActive());
        }
        if (tagList.Contains("Blue") && tagList.Contains("Yellow"))
        {
            StartCoroutine(Capsule2Active());
        }
        if (tagList.Contains("Yellow") && tagList.Contains("Green"))
        {
            StartCoroutine(Cube2Active());
        }
    }

    IEnumerator cubeActive()
    {
        yield return new WaitForSeconds(1.0f);
        Cube.SetActive(true);
    }
    IEnumerator capsule1Active()
    {
        yield return new WaitForSeconds(1.0f);
        Capsule1.SetActive(true);
    }
    IEnumerator CylinderActive()
    {
        yield return new WaitForSeconds(1.0f);
        Cylinder.SetActive(true);
    }
    IEnumerator SphereActive()
    {
        yield return new WaitForSeconds(1.0f);
        Sphere.SetActive(true);
    }
    IEnumerator Capsule2Active()
    {
        yield return new WaitForSeconds(1.0f);
        Capsule2.SetActive(true);
    }
    IEnumerator Cube2Active()
    {
        yield return new WaitForSeconds(1.0f);
        Cube2.SetActive(true);
    }
}
