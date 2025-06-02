using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIPuzzle : MonoBehaviour
{
    public GameObject interactionText;             // "Press E" �ؽ�Ʈ
    public GameObject interactionPanel;            // ���� UI �г�
    public MonoBehaviour playerMovementScript;     // �÷��̾� �̵� ��ũ��Ʈ
    public Rigidbody playerRigidbody;              // �÷��̾� Rigidbody
    public CameraRot cameraRotScript;              // ī�޶� ȸ�� ��ũ��Ʈ

    public Button[] numberButtons = new Button[9]; // ���� ��ư�� (1~9)

    private bool playerInRange = false;
    private bool isInteracting = false;
    private Vector3 savedVelocity;
    private List<int> buttonSequence = new List<int>();

    void Start()
    {
        interactionText.SetActive(false);
        interactionPanel.SetActive(false);

        // ��ư Ŭ�� �̺�Ʈ ����
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int number = i + 1;
            if (numberButtons[i] != null)
                numberButtons[i].onClick.AddListener(() => OnNumberButtonClicked(number));
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isInteracting)
        {
            StartInteraction();
        }
        else if (isInteracting && Input.GetKeyDown(KeyCode.Escape))
        {
            EndInteraction();
        }

        if (isInteracting)
        {
            CheckNumberKeyInput();
        }
    }

    void CheckNumberKeyInput()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                AddNumberToSequence(i);
            }
        }
    }

    void OnNumberButtonClicked(int number)
    {
        if (isInteracting)
        {
            AddNumberToSequence(number);
        }
    }

    void AddNumberToSequence(int number)
    {
        buttonSequence.Add(number);

        if (buttonSequence.Count == 2)
        {
            if (buttonSequence[0] == 1 && buttonSequence[1] == 5)
            {
                Debug.Log("���");
            }
            else
            {
                Debug.Log("����");
            }

            buttonSequence.Clear();
        }
    }

    void StartInteraction()
    {
        isInteracting = true;
        interactionPanel.SetActive(true);
        interactionText.SetActive(false);
        buttonSequence.Clear();

        if (playerMovementScript != null) playerMovementScript.enabled = false;

        if (playerRigidbody != null)
        {
            savedVelocity = playerRigidbody.velocity;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (cameraRotScript != null)
            cameraRotScript.enabled = false; // ī�޶� ȸ�� ��Ȱ��ȭ

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void EndInteraction()
    {
        isInteracting = false;
        interactionPanel.SetActive(false);

        if (playerMovementScript != null) playerMovementScript.enabled = true;

        if (playerRigidbody != null)
        {
            playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            playerRigidbody.velocity = savedVelocity;
        }

        if (cameraRotScript != null)
            cameraRotScript.enabled = true; // ī�޶� ȸ�� �ٽ� Ȱ��ȭ

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerInRange)
        {
            interactionText.SetActive(true);
        }

        buttonSequence.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!isInteracting)
                interactionText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionText.SetActive(false);
            if (isInteracting)
            {
                EndInteraction();
            }
        }
    }
}
