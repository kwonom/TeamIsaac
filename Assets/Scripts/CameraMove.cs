using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _realCam;
    [SerializeField] Player _player;

    public float lerpTime;
    public float currentTime;
    public float velo;
    
    public enum EMove
    {
        None,
        Top,
        Bottom,
        Right,
        Left,

    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        

        Vector3 cameraPos = _realCam.position;

        Vector3 target1 = new Vector3(0, 48f, 0);//top

        Vector3 target2 = new Vector3(0, -48f, 0);//bottom

        Vector3 target3 = new Vector3(72f, 0, 0);//Right

        Vector3 target4 = new Vector3(-72f, 0, 0);//Left

        if (_player.isTouchTop)
        {

             transform.position += Vector3.Lerp(_realCam.position, target1, currentTime / lerpTime);
           
            _player.isTouchTop = false;
              
           

        }
        if (_player.isTouchBottom)
        {
            transform.position += Vector3.Lerp(_realCam.position, target2, 1f);
            _player.isTouchBottom = false;
        }
        if (_player.isTouchRight)
        {
            transform.position += Vector3.Lerp(_realCam.position, target3, 1f);
            _player.isTouchRight = false;
        }
        if (_player.isTouchLeft)
        {
            transform.position += Vector3.Lerp(_realCam.position, target4, 1f);
            _player.isTouchLeft = false;
        }

    }



   
    

}