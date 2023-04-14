using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorMove : MonoBehaviour
{
    float x;
    float y;
    [SerializeField] RectTransform _cursor;
    private void Update()
    {

       
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

       // Debug.Log("rectTransform.position :" + _cursor);

        //if ((x == 1) || (y == -1))
        //{
        //    transform.position = Vector2.Lerp(transform.position,new Vector2(0, -315),Time.deltaTime);
        //}
    }
}
