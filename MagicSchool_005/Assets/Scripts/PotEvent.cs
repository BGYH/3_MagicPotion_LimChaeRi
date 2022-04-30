using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Threading;

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

    public GameObject Dragon_G;
    public GameObject Dragon_B;
    public GameObject Dragon_R;
    public GameObject Corgi_1;
    public GameObject Dragon_Y;
    public GameObject Corgi_2;

    public ParticleSystem Pongdang; //파티클시스템
    public ParticleSystem Bubble; //파티클시스템

    private Collider coll;
    public List<string> tagList = new List<string>();
    //public List<string, string> tagNname = new List<string, string>();
    //public string[,] tagNname = new string[4, 2];
    public Dictionary<string, string> tagNname = new Dictionary<string, string>()
    {
        {"Red", "힘"},
        {"Blue", "용기"},
        {"Green", "행운"},
        {"Yellow", "지혜"}

    };

    private int cnt = 0;

    public GameObject chatController;

    // Start is called before the first frame update
    void Start()
    {
        Dragon_G.SetActive(false);
        Dragon_B.SetActive(false);
        Dragon_R.SetActive(false);
        Corgi_1.SetActive(false);
        Dragon_Y.SetActive(false);
        Corgi_2.SetActive(false);
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
            Potion_B.SetActive(false); Potion_R.SetActive(false);
            Potion_G.SetActive(false); Potion_Y.SetActive(false);
            Invoke("DragonAppear", 1.5f);
        }
    }

    public void DragonAppear()
    {
        Debug.Log("tagList : " + tagList[0] + ", " + tagList[1]);
        Bubble.Play();

        if (tagList.Contains("Red") && tagList.Contains("Blue"))
        {
            Dragon_R.SetActive(true);
            Debug.Log("Dragon_R appear");
        }
        if (tagList.Contains("Red") && tagList.Contains("Green"))
        {
            Dragon_B.SetActive(true);
            Debug.Log("Dragon_B appear");
        }
        if (tagList.Contains("Red") && tagList.Contains("Yellow"))
        {
            Corgi_1.SetActive(true);
            Debug.Log("Corgi1 appear");
        }
        if (tagList.Contains("Blue") && tagList.Contains("Green"))
        {
            Dragon_G.SetActive(true);
            Debug.Log("Dragon_G appear");
        }
        if (tagList.Contains("Blue") && tagList.Contains("Yellow"))
        {
            Corgi_2.SetActive(true);
            Debug.Log("Corgi2 appear");
        }
        if (tagList.Contains("Yellow") && tagList.Contains("Green"))
        {
            Dragon_Y.SetActive(true);
            Debug.Log("Dragon_Y appear");
        }

        StartCoroutine(chatController.GetComponent<chatController>().whichDragon());
    }
}
