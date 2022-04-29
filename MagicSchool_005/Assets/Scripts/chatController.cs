using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class chatController : MonoBehaviour
{
    public XRController controller = null;
    public GameObject potEvent;

    public Text ChatText;
    public string writerText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());

    }

    public void whichDragon()
    {
        //potEvent = GameObject.Find("Vis").GetComponent<PotEvent>();
        List<string> DragonTags = potEvent.GetComponent<PotEvent>().tagList;
        Debug.Log("***********    DragonTags : " + DragonTags[0] + ", " + DragonTags[1] + "    *******************");

        if (DragonTags.Contains("Red") && DragonTags.Contains("Blue"))
        {
            StartCoroutine(RBtext());
        }
        else if (DragonTags.Contains("Red") && DragonTags.Contains("Green"))
        {
            StartCoroutine(RGtext());
        }
        else if (DragonTags.Contains("Red") && DragonTags.Contains("Yellow"))
        {
            StartCoroutine(RYtext());
        }
        else if (DragonTags.Contains("Blue") && DragonTags.Contains("Green"))
        {
            StartCoroutine(BGtext());
        }
        else if (DragonTags.Contains("Blue") && DragonTags.Contains("Yellow"))
        {
            StartCoroutine(BYtext());
        }
        else if (DragonTags.Contains("Yellow") && DragonTags.Contains("Green"))
        {
            StartCoroutine(GYtext());
        }
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

    IEnumerator RBtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("용기와 힘의 드래곤을 탄생시켰구나."));
        yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator RGtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("힘과 행운의 드래곤을 탄생시켰구나."));
        yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator RYtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("힘과 지혜의 드래곤을 탄생시켰구나."));
        yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator BGtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("행운과 용기의 드래곤을 탄생시켰구나."));
        yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator BYtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("용기와 지혜의 드래곤을 탄생시켰구나."));
        yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator GYtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("지혜와 행운의 드래곤을 탄생시켰구나."));
        yield return StartCoroutine(NormalChat("이제 드래곤과 함께 마법학교를 탐방하러 가볼까?"));
        yield return StartCoroutine(NormalChat("   "));
    }
}
