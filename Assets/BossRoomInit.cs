using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomInit : MonoBehaviour
{
    [SerializeField] GameUI gameUI;
    [SerializeField] Player player;
    void Start()
    {
        gameUI.BossRoomInit();
        player.BossRoomInit();
    }

    void Update()
    {
        
    }
}
