using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorfController : MonoBehaviour
{
    GameObject _horf;    // Start is called before the first frame update
    void Start()
    {
        _horf = Resources.Load("Prefabs/Horf") as GameObject;
        makeHorf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeHorf()
    {
        for(int i = 0; i < 1; i++)
        {
            GameObject horf = Instantiate(_horf, _horf.transform.position, Quaternion.identity);
            horf.GetComponent<Horf>();
        }
    }
}
