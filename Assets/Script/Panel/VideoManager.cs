using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public Button videoButton; // �޴�ĵ������ ���� ��ư
    public Button quitButton; // ���� ĵ������ ���� ��ư
    public GameObject canvasGameObject; // ĵ����
    public GameObject xrRig; // �÷��̾� ��ǥ (���� ī�޶� ���� xrRig ��ǥ�� �����)
    public Canvas canvasComponent; // canvasGameObject�� ���� ��
    public float canvasDistanceForward = 0.4f; // �÷��̾�κ��� ���� 0.4f(���ǿ����� �� 40cm ����)�� ĵ���� Ȱ��ȭ
    public float height = 1.3f; // ĵ���� ���� = 1.3m
    public VideoPlayer videoPlayer; // VideoPlayer ������Ʈ

    private bool isCanvasVisible = false; // ó������ ĵ���� ��Ȱ��ȭ

    void Start()
    {
        canvasGameObject.SetActive(false);
        videoButton.onClick.AddListener(ToggleMainCanvas); // Video ��ư Ŭ�� �̺�Ʈ �߰�
        quitButton.onClick.AddListener(HideCanvas); // Quit ��ư Ŭ�� �̺�Ʈ �߰�
    }

    private void ToggleMainCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        canvasGameObject.SetActive(isCanvasVisible);

        // ĵ���� Ȱ��ȭ ��ǥ
        if (isCanvasVisible && xrRig != null)
        {
            // � �������ε� ���� 40cm �տ� ĵ������ ��Ÿ���� �� -> Quarternion ����� ���� ���
            Quaternion rotation = Quaternion.Euler(0, xrRig.transform.eulerAngles.y, 0);
            Vector3 forwardDirection = rotation * Vector3.forward;

            // ĵ���� Ȱ��ȭ ��ǥ ���
            Vector3 canvasPosition = xrRig.transform.position + forwardDirection * canvasDistanceForward;
            canvasPosition.y = height;

            canvasGameObject.transform.position = canvasPosition;
            // ĵ������ �÷��̾ ��� ����(�� ������ �޶�) �׻� �÷��̾� �þ� ���鿡 ��Ÿ���� ĵ���� ���� ����
            canvasGameObject.transform.rotation = rotation;
        }
    }

    private void HideCanvas()
    {
        isCanvasVisible = false;
        canvasGameObject.SetActive(false);

        // ���� �ʱ�ȭ
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.time = 0;
        }
    }
}
