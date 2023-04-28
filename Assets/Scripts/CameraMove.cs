using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _realCam;
    [SerializeField] Player _player;


    private void Update()
    {
       
        Vector3 target1 = new Vector3(0, 48f, 0);//top

        Vector3 target2 = new Vector3(0, -48f, 0);//bottom

        Vector3 target3 = new Vector3(72f, 0, 0);//Right

        Vector3 target4 = new Vector3(-72f, 0, 0);//Left

        if (_player.IsTouchTop)
        {
            transform.position += Vector3.Lerp(_realCam.position, target1, 1f);
            _player.IsTouchTop = false;
        }
        if (_player.IsTouchBottom)
        {
            transform.position += Vector3.Lerp(_realCam.position, target2, 1f);
            _player.IsTouchBottom = false;
        }
        if (_player.IsTouchRight)
        {
            transform.position += Vector3.Lerp(_realCam.position, target3, 1f);
            _player.IsTouchRight = false;
        }
        if (_player.IsTouchLeft)
        {
            transform.position += Vector3.Lerp(_realCam.position, target4, 1f);
            _player.IsTouchLeft = false;
        }
    }
}