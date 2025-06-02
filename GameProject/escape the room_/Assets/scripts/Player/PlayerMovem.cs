using UnityEngine;

public class PlayerMovem : MonoBehaviour
{
     // �÷��̾��� CharacterController
    public float speed = 5f;  // �̵� �ӵ�
    public float gravity = -9.8f;  // �߷�
    public float jumpHeight = 3f;  // ���� ����
    private float ySpeed = 0f;  // Y�� �ӵ� (�߷¿� ���� ���������� ��ȭ)

    void Update()
    {
        // ���� �̵� �Է� (W, A, S, D)
        float x = Input.GetAxis("Horizontal");  // A/D (�¿�)
        float z = Input.GetAxis("Vertical");  // W/S (�յ�)

        // �̵� ����
        Vector3 move = transform.right * x + transform.forward * z;
        transform.position += move * Time.deltaTime;

        // ���� ó��
        

        // �߷� ó��
        ySpeed += gravity * Time.deltaTime;  // ���������� �߷� ����

        // �̵� ���Ϳ� y�� �ӵ� �ݿ�
        move.y = ySpeed;

        // �̵� ó��
       
    }
}
