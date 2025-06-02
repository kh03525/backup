using System.Collections.Generic;
using UnityEngine;

public class BtnPuzzleManager : MonoBehaviour
{
    public GameObject doorToOpen;
    public List<PuzzleButton> buttons = new List<PuzzleButton>();
    public HintData hintData;

    private List<int> correctOrder = new List<int>();
    private int currentOrder = 0;

    void Start()
    {
        LoadCorrectOrderFromHintData();
    }

    void LoadCorrectOrderFromHintData()
    {
        if (hintData == null)
        {
            Debug.LogError("HintData�� �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }

        correctOrder.Clear();

        foreach (var entry in hintData.entries)
        {
            correctOrder.Add(entry.buttonIndex);
        }
    }

    public void ButtonPressed(PuzzleButton button)
    {
        // �̹� ���� ��ư�̸� ���� (���� �ߺ� ����)
        if (button.IsActivated()) return;

        if (button.buttonOrder == correctOrder[currentOrder])
        {
            button.Activate();
            Debug.Log("�ùٸ� ��ư�� �������ϴ�: " + button.buttonOrder);
            currentOrder++;

            if (currentOrder >= correctOrder.Count)
            {
                Debug.Log("���� �Ϸ�! ���� �����ϴ�.");
                if (doorToOpen != null)
                    doorToOpen.GetComponent<Animator>().SetTrigger("Open");
            }
        }
        else
        {
            Debug.Log("Ʋ�Ƚ��ϴ�! ������ �ʱ�ȭ�˴ϴ�.");
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        currentOrder = 0;
        foreach (var button in buttons)
        {
            button.ResetButton(); // ResetButton �ȿ��� ����+����Ʈ ó��
        }
    }
}
