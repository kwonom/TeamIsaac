using UnityEngine;

public class HorfController : MonoBehaviour
{
    GameObject _horf;

    void Start()
    {
        _horf = Resources.Load("Prefabs/Horf") as GameObject;
        makeHorf();
    }

    public void makeHorf()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject horf = Instantiate(_horf, _horf.transform.position, Quaternion.identity);
            horf.GetComponent<Horf>();
        }
    }
}
