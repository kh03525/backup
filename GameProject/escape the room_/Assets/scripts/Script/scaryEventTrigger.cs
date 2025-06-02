using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryEventTrigger : MonoBehaviour
{
    public GameObject scare;
    public AudioSource scareSound;
    public Collider collision;

    void Start()
    {
        // ���� ���� �� scare ������Ʈ ��Ȱ��ȭ
        if (scare != null)
        {
            scare.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // scare ������Ʈ Ȱ��ȭ
            if (scare != null)
            {
                scare.SetActive(true);
            }

            // ���� ��� (�ּ� ���� ��)
            if (scareSound != null)
            {
                scareSound.Play();
            }

            // Ʈ���� �� ���� �۵��ϵ��� �ݶ��̴� ��Ȱ��ȭ
            if (collision != null)
            {
                collision.enabled = false;
            }
        }
    }
}
