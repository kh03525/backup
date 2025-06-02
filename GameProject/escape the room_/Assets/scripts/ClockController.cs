using UnityEngine;
using TMPro;  // TextMeshPro ���ӽ����̽�
using UnityEngine.SceneManagement;  // �� ��ȯ�Ϸ��� �ʿ��ؿ�

public class ClockController : MonoBehaviour
{
    public TextMeshProUGUI clockText;  // �ؽ�Ʈ ������Ʈ�� ������ ����
    private int hours = 5;  // ���� �ð� (5��)
    private int minutes = 0;  // ���� �� (0��)
    public TextMeshProUGUI messageText;  // �޽��� �ؽ�Ʈ�� ������ ����

    void Start()
    {
        UpdateClockDisplay();  // �ð� ������Ʈ
    }

    // �ð踦 ������Ʈ�ϴ� �Լ�
    void UpdateClockDisplay()
    {
        clockText.text = string.Format("{0:D2}:{1:D2}", hours, minutes);  // �ð��� "05:00" �������� ǥ��
        CheckGoalTime();  // ��ǥ �ð� Ȯ��
    }

    // +1�� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void AddMinute()
    {
        minutes++;
        if (minutes >= 60)  // 60���� ������ 1�ð� �߰�
        {
            minutes = 0;
            hours++;
            if (hours >= 24)  // 24�ð��� ������ 0�÷� ���ư���
            {
                hours = 0;
            }
        }
        UpdateClockDisplay();
    }

    // -1�� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void SubtractMinute()
    {
        minutes--;
        if (minutes < 0)  // 0�к��� ������ 1�ð� ����
        {
            minutes = 59;
            hours--;
            if (hours < 0)  // 0�ú��� ������ 23�÷� ���ư���
            {
                hours = 23;
            }
        }
        UpdateClockDisplay();
    }

    // ��ǥ �ð�(5:24)�� �������� �� ȣ��Ǵ� �Լ�
    void CheckGoalTime()
    {
        if (hours == 5 && minutes == 24)
        {
            messageText.text = "����ö�� Ż �� �ֽ��ϴ�!";  // ���� �޽��� ���
        }
        else
        {
            messageText.text = "";  // ��ǥ �ð��� �������� �ʾ��� ��� �޽��� ����
        }
    }

    public void TryBoardTrain()
    {
        if (hours == 5 && minutes == 24)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            messageText.text = "���� ����ö�� Ż �� �����ϴ�!";
        }
    }
}
