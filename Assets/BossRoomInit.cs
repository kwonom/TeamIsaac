using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoomInit : MonoBehaviour
{
    [SerializeField] Player player;
    void Start()
    {
        Debug.Log("start boss room");
        GameUI.instance.BossRoomInit();
        player.BossRoomInit();
    }
    public void OnBtnEXIT()
    {
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1;
    }
    public void OnBtnRESTART()
    {
        SceneManager.LoadScene("BossRoom");
        Time.timeScale = 1f;
    }

   

}
