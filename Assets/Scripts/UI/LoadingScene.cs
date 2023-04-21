using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GoMain());
    }

    void Update()
    {
        
    }

    IEnumerator GoMain()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Main");
    }
}
