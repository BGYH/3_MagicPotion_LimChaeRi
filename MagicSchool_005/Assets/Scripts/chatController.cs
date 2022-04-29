using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class chatController : MonoBehaviour
{
    public XRController controller = null;

    public Text ChatText;
    public string writerText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
