using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonToggler : MonoBehaviour
{
    public Button aButton; // ��ư�� ������ ����
    public Image[] images; // �̹������� ������ �迭
    private int currentIndex = 0; // ���� ǥ���� �̹��� �ε���

    void Start()
    {
        // ��ư Ŭ�� �� OnButtonClick �Լ� ȣ�� ����
        aButton.onClick.AddListener(OnButtonClick);

        // ��� �̹����� ��Ȱ��ȭ�ϰ� ù ��° �̹����� Ȱ��ȭ
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i == 0);
        }
    }

    void OnButtonClick()
    {
        // ������ �̹����� Ȱ��ȭ�� ���¸� �� ���·� �ߴ�
        if (currentIndex >= images.Length - 1)
        {
            return;
        }

        // ���� �̹����� ��Ȱ��ȭ�ϰ� ���� �̹����� Ȱ��ȭ
        images[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        images[currentIndex].gameObject.SetActive(true);
    }
}
