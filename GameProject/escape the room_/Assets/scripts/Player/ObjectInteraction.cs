using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactRange = 3f; // ��ȣ�ۿ� ������ �Ÿ�

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //EŰ ������ ��ȣ�ۿ�
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactRange))
        {
            if (hit.collider.CompareTag("Object"))
            {
                Debug.Log("Object�� ��ȣ�ۿ���: " + hit.collider.name);
                Debug.Log("�ȳ��ϼ���"); // ��ȣ�ۿ� �� "�ȳ��ϼ���" ���
                
            }
        }
    }
}