using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxSpeedMoving : MonoBehaviour
{
    public Button buttonToClick; // Ŭ���ϴ� ��ư
    public Image lightImage; // ���<->������ �̹��� (��ư�� �� Ŭ���Ǿ����� Ȯ���ϴ� �뵵)
    public GameObject upperGameObject; // �� ���ӿ�����Ʈ (ī�޶�)
    public GameObject lowerGameObject; // �Ʒ� ���ӿ�����Ʈ (ħ��)
    public float speed = 0.1f; // lowerGameObject�� �̵� �ӵ�
    public float distance = -0.3f; // upperGameObject�� lowerGameObject ������ �Ÿ�
    public TextMeshProUGUI statusText;

    private bool isGreen = false; // lightImage �� ��ȭ ����
    private Vector3 initialLowerGameObjectPosition; // �ʱ� �Ʒ� ���ӿ�����Ʈ ��ġ
    private bool isLowerGameObjectMoved = false; // �Ʒ� ���ӿ�����Ʈ ������ ����

    private static readonly Color RED_COLOR = Color.red;
    private static readonly Color GREEN_COLOR = Color.green;

    void Start()
    {
        buttonToClick.onClick.AddListener(HandleButtonClick);
        initialLowerGameObjectPosition = lowerGameObject.transform.position;

        // �ʱ� ������ ���������� ����
        lightImage.color = RED_COLOR;
        statusText.text = "OFF";
    }

    void Update()
    {
        if (isLowerGameObjectMoved)
        {
            MoveLowerGameObjectTowardsTarget();
        }
    }

    private void MoveLowerGameObjectTowardsTarget()
    {
        Vector3 targetPosition = GetTargetPosition();
        lowerGameObject.transform.position = Vector3.MoveTowards(lowerGameObject.transform.position, targetPosition, speed * Time.deltaTime);
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(lowerGameObject.transform.position.x, upperGameObject.transform.position.y + distance, lowerGameObject.transform.position.z);
    }

    private void HandleButtonClick()
    {
        ToggleLightColor();
        ToggleLowerGameObjectMovement();
    }

    private void ToggleLightColor()
    {
        if (lightImage.color == RED_COLOR)
        {
            lightImage.color = GREEN_COLOR;
            statusText.text = "ON";
        }
        else
        {
            lightImage.color = RED_COLOR;
            statusText.text = "OFF";
        }
    }

    private void ToggleLowerGameObjectMovement()
    {
        isLowerGameObjectMoved = !isLowerGameObjectMoved;
    }
}
