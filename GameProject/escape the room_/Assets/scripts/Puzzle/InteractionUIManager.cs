using UnityEngine;
using UnityEngine.UI;

public class InteractionUIManager : MonoBehaviour
{
    public float interactDistance = 3f;  // ��ȣ�ۿ� ������ �Ÿ�
    public KeyCode interactKey = KeyCode.E;  // ��ȣ�ۿ� Ű (EŰ)
    public GameObject interactionUI;  // UI�� ��ü �г� (Image�� Button�� ����)
    public GameObject interactionPanel;  // ��ȣ�ۿ� �� ��Ÿ�� Panel (UI �г�)
    public Image interactionImage;  // ��ȣ�ۿ� �� ��Ÿ�� �̹���
    public Text interactText;  // "E�� ��������" �ؽ�Ʈ
    public Button[] interactionButtons;  // 9���� ��ư �迭

    // ���� ���� ����
    private bool isButton1Pressed = false;  // 1�� ��ư�� ���ȴ��� ���� ����

    private void Start()
    {
        // UI�� ó������ ��Ȱ��ȭ ���·� ����
        interactionUI.SetActive(false);
        interactionPanel.SetActive(false);  // interactionPanel�� ��Ȱ��ȭ ���·� ����
        interactText.gameObject.SetActive(false);  // �ؽ�Ʈ�� ��Ȱ��ȭ

        // �� ��ư�� Ŭ�� �̺�Ʈ ����
        for (int i = 0; i < interactionButtons.Length; i++)
        {
            int buttonIndex = i; // ���� ������ �ε����� ĸó (Button Ŭ�� �� �ʿ�)
            interactionButtons[buttonIndex].onClick.AddListener(() => OnButtonClicked(buttonIndex));
        }

        // ó������ �̹����� ��Ȱ��ȭ (UI�� ��Ȱ��ȭ �Ǹ� �̹����� ������ �ʵ���)
        if (interactionImage != null)
        {
            interactionImage.gameObject.SetActive(false);  // �̹��� ��Ȱ��ȭ
        }
    }

    private void Update()
    {
        // �÷��̾ �� ������Ʈ�� ��ȣ�ۿ��� �� �ִ� �Ÿ��� �ִ��� Ȯ��
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (distance <= interactDistance)
        {
            // EŰ�� ������ �� ��ȣ�ۿ�
            interactText.gameObject.SetActive(true);  // �ؽ�Ʈ Ȱ��ȭ
            interactText.text = "E�� ���� ��ȣ�ۿ�";  // �ؽ�Ʈ ����

            // EŰ�� ������ �� ��ȣ�ۿ�
            if (Input.GetKeyDown(interactKey))
            {
                Interact();  // �г��� ���� �Լ� ȣ��
            }
        }
        else
        {
            // ��ȣ�ۿ� ������ ����� �ؽ�Ʈ ��Ȱ��ȭ
            interactText.gameObject.SetActive(false);
        }

        // ESCŰ�� ������ �� UI�� ��Ȱ��ȭ�ϰų� ������ ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
        }

        // Ű 1, 5�� ������ �� �ֿܼ� "���" �޽��� ���
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isButton1Pressed = true;  // ��ư 1 ���� ���� ����
            Debug.Log("��ư 1 ����");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (isButton1Pressed)  // ��ư 1�� ���� ������ ���� ���
            {
                Debug.Log("���");
                isButton1Pressed = false;  // ���� �ʱ�ȭ
            }
            else
            {
                Debug.Log("��ư 5�� ����");
            }
        }
    }

    // ��ȣ�ۿ� �Լ� (E�� ������ �� �г��� ���)
    private void Interact()
    {
        // UI �г��� Ȱ��ȭ (interactionPanel)
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(true);  // interactionPanel�� Ȱ��ȭ
        }

        // �̹����� �����ϸ� Ȱ��ȭ
        if (interactionImage != null)
        {
            interactionImage.gameObject.SetActive(true);  // �̹��� Ȱ��ȭ
            interactionImage.color = Color.white;  // �̹��� ������ ������� ���� (���̵���)
        }

        // ��ư�� Ȱ��ȭ
        foreach (Button button in interactionButtons)
        {
            button.gameObject.SetActive(true);
        }

        // ��ȣ�ۿ� �� �ؽ�Ʈ�� ��Ȱ��ȭ
        interactText.gameObject.SetActive(false);
    }

    // ��ư Ŭ�� �� ����� �Լ�
    private void OnButtonClicked(int buttonIndex)
    {
        // Button1 (index 0)�� Button5 (index 4)�� Ŭ������ �� "���" �޽��� ���
        if (buttonIndex == 0 && !isButton1Pressed)  // ��ư 1�� Ŭ������ ��
        {
            isButton1Pressed = true;
            Debug.Log("��ư 1 Ŭ����");
        }
        else if (buttonIndex == 4 && isButton1Pressed)  // ��ư 5�� Ŭ������ ��
        {
            Debug.Log("���");
            isButton1Pressed = false;  // ���� �ʱ�ȭ
        }
        else
        {
            Debug.Log("��ư " + (buttonIndex + 1) + " Ŭ����");
        }

        // UI ��Ȱ��ȭ (��ȣ�ۿ��� ������ ��)
        interactionPanel.SetActive(false);  // interactionPanel ��Ȱ��ȭ
    }

    // ESCŰ�� ������ �� UI�� �ݰų� ������ �����ϴ� �Լ�
    private void CloseUI()
    {
        // UI�� Ȱ��ȭ�Ǿ� ������ ��Ȱ��ȭ
        if (interactionPanel.activeSelf)
        {
            interactionPanel.SetActive(false);
        }
        else
        {
            // ������ �����Ϸ��� �� �κ��� ���
            // Application.Quit();  // ���� ���� (���� ���忡���� �۵�)

            // �����Ϳ����� ���ᰡ �ȵǹǷ�, �����Ϳ��� ������ ���� ����� �� �ֵ��� �Ʒ� �ڵ带 �߰�
            Debug.Log("ESC Ű ����: ���� ���� �Ǵ� UI �ݱ�");
        }
    }
}