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

        //�ؽ�Ʈ Ÿ���� ȿ��
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //Ű�� �ٽ� ���������� ������ ���
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
        yield return StartCoroutine(NormalChat("���� 4���� �������� ������?"));
        yield return StartCoroutine(NormalChat("���ϴ� ������ 2���� ������ ������ �׾Ƹ��� �ϳ��� �־��."));
        yield return StartCoroutine(NormalChat("�ʸ��� �巡���� ��Ÿ���ž�!"));
        yield return StartCoroutine(NormalChat("(Grip�� �̿��� �������� ��� �׾Ƹ��� �־����. ���� ������ �ٽ� ������ �� �ֽ��ϴ�.)"));
        yield return StartCoroutine(NormalChat("   "));
    }
}
