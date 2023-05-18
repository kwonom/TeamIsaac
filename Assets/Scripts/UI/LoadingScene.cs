using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GoMain());
    }

    IEnumerator GoMain()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main");
    }
}
