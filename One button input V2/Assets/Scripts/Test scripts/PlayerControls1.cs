using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls1 : MonoBehaviour
{
    
    public float speed;
    public GameObject bullet;
    
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window

    }
    // Update is called once per frame
    void Update()
        {
        //temporary storage to calculate movement vector
        Vector3 rotation;
        //assigns the x axis of the moement vector to match the player horizontal input.
        rotation.x = 0;
        //Leave the y axis alone, as we do not want to move up and down
        rotation.y = Input.GetAxis("Mouse X");
       
        //Test of input.mousePosition
        /*rotation.y = Input.mousePosition - Camera.main.ScreenToWorldPoint(transform.position);*/
       // rotation.y = (Input.mousePosition - Camera.main.ScreenToWorldPoint(transform.position));
       
        //assigns the z axis of the movement vector to match the players vertical input.
        rotation.z = Input.GetAxis("Mouse Y");
        //make vector framerate independant
        rotation *= Time.deltaTime;
        //apply speed multiplier
        rotation *= speed;

        //move by a dactor of 'movement'
        transform.LookAt(rotation);// Camera.main.ScreenToWorldPoint(transform.position);


        //can shoot
        if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Fire1");
                Instantiate(bullet, transform.position, transform.rotation);
            }
            // can get killed by enemy

           
        }
}