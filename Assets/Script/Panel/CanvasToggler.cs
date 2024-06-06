using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToggler : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch; // ���� �� = ���� ��Ʈ�ѷ�
    public GameObject menuPanel; // �г�(�е�)
    public GameObject xrRig; // �÷��̾� ��ǥ (���� ī�޶� ���� xrRig ��ǥ�� �����)
    public float canvasDistanceForward = 0.6f; // �÷��̾�κ��� ���� 0.6f(���ǿ����� �� 60cm ����)�� �г� Ȱ��ȭ
    public float height = 1.3f; // �г� ���� = 1.3m

    private bool isCanvasVisible = false; // ó������ �г� ��Ȱ��ȭ
    private float lastXButtonTime = 0f; // �г� Ȱ��ȭ ����� ���� Ŭ������ �� -> ����Ŭ���� ���� ����
    public float doubleClickThreshold = 0.3f;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    void Update()
    {
        // ���� ��� �޼��� ������ ������ �ι� �΋H���� �� = ��Ʈ�ѷ��� ��� ���� ��Ʈ�ѷ��� ù��° ��ư(OVRInput.Button.One)�� ���� Ŭ���ϴ� ��
        if (OVRInput.GetDown(OVRInput.Button.One, leftController))
        {
            float currentTime = Time.time;
            if (currentTime - lastXButtonTime <= doubleClickThreshold)
            {
                ToggleMainCanvas();
            }
            lastXButtonTime = currentTime;
        }
    }

    private void ToggleMainCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        menuPanel.SetActive(isCanvasVisible);

        // �г� Ȱ��ȭ ��ǥ
        if (isCanvasVisible && xrRig != null)
        {
            // � �������ε� ���� 60cm �տ� �г��� ��Ÿ���� �� -> Quarternion ����� ���� ���
            Quaternion rotation = Quaternion.Euler(0, xrRig.transform.eulerAngles.y, 0);
            Vector3 forwardDirection = rotation * Vector3.forward;

            // �г� Ȱ��ȭ ��ǥ ���
            Vector3 canvasPosition = xrRig.transform.position + forwardDirection * canvasDistanceForward;
            canvasPosition.y = height;

            menuPanel.transform.position = canvasPosition;

            // �г��� �÷��̾ ��� ����(�� ������ �޶�) �׻� �÷��̾� �þ� ���鿡 ��Ÿ���� ĵ���� ���� ����
            menuPanel.transform.rotation = rotation;

            // �г��� 40���� ȸ����Ŵ (x�� ���� ȸ��)
            menuPanel.transform.Rotate(40, 0, 0);
        }
    }
}
