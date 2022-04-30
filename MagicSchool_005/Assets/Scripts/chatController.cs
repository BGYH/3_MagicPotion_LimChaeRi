using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class chatController : MonoBehaviour
{
    public XRController controller = null;
    public GameObject potEvent;
    public GameObject Dragon_G;
    public GameObject Dragon_B;
    public GameObject Dragon_R;
    public GameObject Corgi_1;
    public GameObject Dragon_Y;
    public GameObject Corgi_2;

    public Text ChatText;
    public string writerText = "";

    public GameObject FadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
    }

    public IEnumerator whichDragon()
    {
        List<string> DragonTags = potEvent.GetComponent<PotEvent>().tagList;
        Debug.Log("***********    DragonTags : " + DragonTags[0] + ", " + DragonTags[1] + "    *******************");
        
        Dictionary<string, string> dic = potEvent.GetComponent<PotEvent>().tagNname;
        dic.TryGetValue("Red", out string R_name);
        dic.TryGetValue("Blue", out string B_name);
        dic.TryGetValue("Green", out string G_name);
        dic.TryGetValue("Yellow", out string Y_name);

        if (DragonTags.Contains("Red") && DragonTags.Contains("Blue"))
        {
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(R_name + "과 " + B_name + "의 드래곤을 탄생시켰구나."));
            yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
            yield return StartCoroutine(NormalChat("   "));
            Dragon_R.GetComponent<dragonHappy>().happyStart();
        }
        else if (DragonTags.Contains("Red") && DragonTags.Contains("Green"))
        {
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(R_name + "과 " + G_name + "의 드래곤을 탄생시켰구나."));
            yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
            yield return StartCoroutine(NormalChat("   "));
            Dragon_B.GetComponent<dragonHappy>().happyStart();
        }
        else if (DragonTags.Contains("Red") && DragonTags.Contains("Yellow"))
        {
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(R_name + "과 " + Y_name + "의 드래곤을 탄생시켰구나."));
            yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
            yield return StartCoroutine(NormalChat("   "));
            Corgi_1.GetComponent<dragonHappy>().happyStart();
        }
        else if (DragonTags.Contains("Blue") && DragonTags.Contains("Green"))
        {
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(B_name + "와 " + G_name + "의 드래곤을 탄생시켰구나."));
            yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
            yield return StartCoroutine(NormalChat("   "));
            Dragon_G.GetComponent<dragonHappy>().happyStart();
        }
        else if (DragonTags.Contains("Blue") && DragonTags.Contains("Yellow"))
        {
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(B_name + "와 " + Y_name + "의 드래곤을 탄생시켰구나."));
            yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
            yield return StartCoroutine(NormalChat("   "));
            Corgi_2.GetComponent<dragonHappy>().happyStart();
        }
        else if (DragonTags.Contains("Yellow") && DragonTags.Contains("Green"))
        {
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(Y_name + "와 " + G_name + "의 드래곤을 탄생시켰구나."));
            yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
            yield return StartCoroutine(NormalChat("   "));
            Dragon_Y.GetComponent<dragonHappy>().happyStart();
        }

        Invoke("SceneChange", 4.5f);
        StartCoroutine(FadeScreen.GetComponent<FadedScreen>().FadeOut());
    }

    IEnumerator NormalChat(string narration)
    {
        int a = 0;
        writerText = "";

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //키를 다시 누를때까지 무한정 대기
        while (true)
        {
            controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton);

            if (AButton)
            {
                Debug.Log("Press A");
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("여기 4개의 마법약이 보이지?"));
        yield return StartCoroutine(NormalChat("원하는 마법약 2개를 선택해 마법의 항아리에 하나씩 넣어봐."));
        yield return StartCoroutine(NormalChat("너만의 드래곤이 나타날거야!"));
        yield return StartCoroutine(NormalChat("(Grip을 이용해 마법약을 잡고 항아리에 넣어보세요. 손을 놓으면 다시 선택할 수 있습니다.)"));
        yield return StartCoroutine(NormalChat("   "));
    }

    void SceneChange()
    {
        SceneManager.LoadScene("testScene");
    }
}
