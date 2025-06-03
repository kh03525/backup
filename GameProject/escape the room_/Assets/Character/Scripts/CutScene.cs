using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // �ٲ� �� �̸� ����
    public float delay = 10f; // 10�� �� ��ȯ

    void Start()
    {
        Invoke("ChangeScene", delay);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
