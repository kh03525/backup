using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    [SerializeField] private float delayBeforeStart = 3f; // ��� �ð�

    void Start()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        SceneManager.LoadScene("MainScene"); // ��� �� MainScene �ٷ� �ε�
    }
}

