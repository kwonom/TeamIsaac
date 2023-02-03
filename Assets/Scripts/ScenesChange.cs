using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    // Start is called before the first frame update    

    // Update is called once per frame
    void Update()
    {        
        
    }    
    
    public void OnButtonStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnButtonLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnButtonRe()
    {
        SceneManager.LoadScene("Main");
    }
}
