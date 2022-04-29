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

    IEnumerator RBtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("���� ���� �巡���� ź�����ױ���."));
        yield return StartCoroutine(NormalChat("���� �巡��� �Բ� �����б��� Ž���Ϸ� ������?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator RGtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("���� ����� �巡���� ź�����ױ���."));
        yield return StartCoroutine(NormalChat("���� �巡��� �Բ� �����б��� Ž���Ϸ� ������?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator RYtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("���� ������ �巡���� ź�����ױ���."));
        yield return StartCoroutine(NormalChat("���� �巡��� �Բ� �����б��� Ž���Ϸ� ������?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator BGtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("���� ����� �巡���� ź�����ױ���."));
        yield return StartCoroutine(NormalChat("���� �巡��� �Բ� �����б��� Ž���Ϸ� ������?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator BYtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("���� ������ �巡���� ź�����ױ���."));
        yield return StartCoroutine(NormalChat("���� �巡��� �Բ� �����б��� Ž���Ϸ� ������?"));
        yield return StartCoroutine(NormalChat("   "));
    }

    IEnumerator GYtext()
    {
        yield return new WaitForSeconds(5.0f * Time.deltaTime);
        yield return StartCoroutine(NormalChat("������ ����� �巡���� ź�����ױ���."));
        yield return StartCoroutine(NormalChat("���� �巡��� �Բ� �����б��� Ž���Ϸ� ������?"));
        yield return StartCoroutine(NormalChat("   "));
    }
}
