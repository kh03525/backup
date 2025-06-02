using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject uiPanel; // UI �г� (�̹��� + ��ư��)
    private bool isPlayerInRange = false;

    void Update()
    {
        // �÷��̾ ��ȣ�ۿ� ������ ���� �� 'E' Ű�� �������� Ȯ��
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("EŰ ����! UI ��� ����.");
            ToggleUI();
        }
    }

    void ToggleUI()
    {
        if (uiPanel != null)
        {
            bool isActive = uiPanel.activeSelf;
            uiPanel.SetActive(!isActive); // UI �г� Ȱ��ȭ/��Ȱ��ȭ
            Debug.Log("UI ���� ��۵�: " + !isActive);
        }
        else
        {
            Debug.LogWarning("UI �г��� ������� �ʾҽ��ϴ�.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ��ȣ�ۿ� ������ ����.");
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ��ȣ�ۿ� �������� ����.");
            isPlayerInRange = false;
        }
    }
}