using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public int buttonOrder;                      // �� ��ư�� ����
    public BtnPuzzleManager puzzleManager;      // ���� �Ŵ��� ����

    [Header("Button Feedback")]
    public Light buttonLight;                   // ��ư ����Ʈ
    public AudioSource audioSource;             // ���� �����
    public AudioClip clickSound;                // Ŭ�� ����

    private bool isActivated = false;           // ��ư�� �̹� ���ȴ��� ����

    public void OnButtonPressed()
    {
        // �̹� ���� ��ư�� ����
        if (isActivated) return;

        puzzleManager.ButtonPressed(this);
    }

    public void Activate()
    {
        isActivated = true;

        // ����Ʈ �ѱ�
        if (buttonLight != null)
            buttonLight.enabled = true;

        // ���� ���
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }

    public void ResetButton()
    {
        isActivated = false;

        // ����Ʈ ����
        if (buttonLight != null)
            buttonLight.enabled = false;
    }

    public bool IsActivated()
    {
        return isActivated;
    }
}
