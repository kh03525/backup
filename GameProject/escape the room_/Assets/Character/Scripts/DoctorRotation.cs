using UnityEngine;

public class DoctorRotation : MonoBehaviour
{
    [Header("ȸ�� ����")]
    public float delayBeforeRotation = 2f;     // ȸ�� ���� �� ��� �ð�
    public float rotationDuration = 2f;        // ȸ�� �ҿ� �ð�
    public float rotationAngleY = 90f;         // Y������ ȸ���� ����

    private float delayTimer = 0f;
    private float rotationTimer = 0f;
    private bool startRotating = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool hasSetTarget = false;

    void Update()
    {
        if (!startRotating)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= delayBeforeRotation)
            {
                startRotating = true;
                rotationTimer = 0f;

                // ���� ȸ�� �������� ��ǥ ȸ���� ����
                initialRotation = transform.rotation;
                targetRotation = Quaternion.Euler(0f, rotationAngleY, 0f) * initialRotation;
            }
        }
        else if (rotationTimer < rotationDuration)
        {
            rotationTimer += Time.deltaTime;
            float t = Mathf.Clamp01(rotationTimer / rotationDuration);
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
        }
        // ȸ�� �Ϸ� �Ĵ� �ƹ� ���� ���� (�ִϸ��̼��� ��� �����)
    }
}