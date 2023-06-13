using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour
{
    [SerializeField] BossMonster _boss;
    
    public void DieEnd()
    {
        _boss.DieEnd();
    }
}
