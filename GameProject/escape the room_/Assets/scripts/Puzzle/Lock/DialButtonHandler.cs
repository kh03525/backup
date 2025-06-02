using UnityEngine;
using TMPro;

public class DialButtonHandler : MonoBehaviour
{
    public TMP_Text dialText;              // �ؽ�Ʈ ǥ��
    public Animator dialAnimator;          // ���̾� ȸ�� �ִϸ��̼�
    public LockManager lockManager;        // ��ü �ڹ��� ���� Ȯ��

    private int currentNumber = 0;
    private bool isLocked = false;

    public void OnClickDial()
    {
        if (isLocked) return;

        currentNumber = (currentNumber + 1) % 10;
        dialText.text = currentNumber.ToString();

        if (dialAnimator != null)
            dialAnimator.SetTrigger("Turn");

        if (lockManager != null)
            lockManager.CheckCombination();
    }

    public int GetCurrentNumber()
    {
        return currentNumber;
    }

    public void ResetToZero()
    {
        currentNumber = 0;
        dialText.text = "0";

        if (dialAnimator != null)
            dialAnimator.SetTrigger("Reset");
    }

    public void LockInput(bool state)
    {
        isLocked = state;
    }
}
