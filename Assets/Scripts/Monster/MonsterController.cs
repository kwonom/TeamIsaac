using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] Transform _hero;
    GameObject _monster;
    List<Monster> mons = new List<Monster>();
    // Start is called before the first frame update
    void Start()
    {
        _monster = Resources.Load("Prefabs/Pooter") as GameObject;
        makeMonsters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeMonsters()
    {

        for (int i = 0; i < 1; i++)
        {
            GameObject mon = Instantiate(_monster, transform);
            mons.Add(mon.GetComponent<Monster>());
        }
        foreach (Monster mon in mons)
        {
            mon.init(this, _hero);
        }
    }
}
