using UnityEngine;
using System.Collections;
//Errors : 17
namespace Debugging.Player
{
    [AddComponentMenu("RPG/Player/MouseLook_1")]
   
    public class MouseLooks : MonoBehaviour
    {
        public enum RotationalAxis
        {
            MouseX,
            MouseZ
        }
        [Header("Rotation Variables")]
        public RotationalAxis axis = RotationalAxis.MouseX;
        [Range(0,200)]
        public float sensitivity = 100;
        public float minY = -60, maxY = 60;
        private float _rotY;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = false;
            }           
            if (GetComponent<Camera>())
            {
                axis = RotationalAxis.MouseZ;
            }
        }
        void Update()
        {
            if(axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime,0);
            }
            else
            {
                _rotY += Input.GetAxis("MouseZ")  * sensitivity * Time.deltaTime;
                _rotY = Mathf.Clamp(_rotY,minY,maxY);
                transform.localEulerAngles = new Vector3(-_rotY,0,0);
            }
        }
    }   
}
