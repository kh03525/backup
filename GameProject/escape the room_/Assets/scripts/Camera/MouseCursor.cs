using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //���콺 Ŀ���� ȭ�鿡�� �߾����� ����
        Cursor.visible = false; // ���콺 Ŀ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
