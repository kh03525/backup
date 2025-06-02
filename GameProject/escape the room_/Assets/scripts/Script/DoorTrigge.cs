using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; // ���� ���� �ִϸ�����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ ������ ���� �۵�
        {
            doorAnimator.SetTrigger("Open"); // Animator�� "Open" Ʈ���� ����
        }
    }
}
