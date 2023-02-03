using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    // Start is called before the first frame update    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene("Main");
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Lobby");
        }
    }    
    public void Dead()
    {
        SceneManager.LoadScene("Lobby");
    }
}
