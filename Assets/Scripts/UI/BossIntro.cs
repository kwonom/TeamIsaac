using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossIntro : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GoBoss());
    }
    IEnumerator GoBoss()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("BossRoom");
    }
}
