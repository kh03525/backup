using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public InputField answerInput;
    public TextMeshProUGUI resultText;
    public GameObject resultPanel; // ���� �߰�: �г� ������Ʈ ����
    public string mainSceneName = "MainScene"; // ���� �� �̸�

    private void Start()
    {
        if (resultPanel != null)
            resultPanel.SetActive(false); // ������ �� �г� �����
    }

    public void CheckAnswer()
    {
        string userInput = answerInput.text.Trim();

        if (resultPanel != null)
            resultPanel.SetActive(true); // ����/���� ������� �г� ���̰�

        if (userInput == "10")
        {
            resultText.text = "O! �����Դϴ�!\nŸ�Ӹӽ��� �۵��մϴ�!";
        }
        else
        {
            resultText.text = "X! Ʋ�Ƚ��ϴ�.\n �ٽ� �õ��ϼ���.";
        }

        StartCoroutine(ReturnToMainAfterDelay(2f)); // ����/���� ������� 2�� �� �̵�
    }

    IEnumerator ReturnToMainAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(mainSceneName);
    }
}
