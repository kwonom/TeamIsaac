using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Player _player;

   public GameObject scanObject;

    public GameObject Top;
    public GameObject Bottom;
    public GameObject Right;
    public GameObject Left;

    float _minDis = 0.1f;
    float _maxDis = 5f;
    

    private void Update()
    {

        Debug.DrawRay(Top.transform.position, Vector2.down *5f, new Color(0, 1, 0));
        Debug.DrawRay(Bottom.transform.position, Vector2.up *5f, new Color(0, 1, 0));
        Debug.DrawRay(Right.transform.position, Vector2.left *5f, new Color(0, 1, 0));
        Debug.DrawRay(Left.transform.position, Vector2.right *5f, new Color(0, 1, 0));

        RaycastHit2D rayHit1 = Physics2D.Raycast(Top.transform.position, Vector2.down, 5f, LayerMask.GetMask("Player"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(Bottom.transform.position, Vector2.up, 5f, LayerMask.GetMask("Player"));
        RaycastHit2D rayHit3 = Physics2D.Raycast(Right.transform.position, Vector2.left, 5f, LayerMask.GetMask("Player"));
        RaycastHit2D rayHit4 = Physics2D.Raycast(Left.transform.position, Vector2.right, 5f, LayerMask.GetMask("Player"));

        float dis1 = Vector2.Distance(Top.transform.position, player.position);
        float dis2 = Vector2.Distance(Bottom.transform.position, player.position);
        float dis3 = Vector2.Distance(Right.transform.position, player.position);
        float dis4 = Vector2.Distance(Left.transform.position, player.position);

      




    }

   

}
