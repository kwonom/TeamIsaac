using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooterController : MonoBehaviour
{
    [SerializeField] Transform _hero;
    GameObject _pooter;
    List<Pooter> pot = new List<Pooter>();
    // Start is called before the first frame update
    void Start()
    {
        _pooter = Resources.Load("Prefabs/Monsters/Pooter") as GameObject;
        makePooter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void makePooter()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject ptr = Instantiate(_pooter, transform);
            pot.Add(ptr.GetComponent<Pooter>());
        }
        foreach (Pooter ptr in pot)
        {
            ptr.Init(this, _hero);
        }
    }
}

