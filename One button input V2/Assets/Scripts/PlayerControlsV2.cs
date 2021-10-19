using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsV2 : MonoBehaviour
{
    
    public float speed;
    public GameObject bullet;
    public bool right;


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

    }
    // Update is called once per frame
    void Update()
    {
        //Test failed
        /*var dir = Input.mousePosition - Camera.main.ScreenToWorldPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);*/

        //Test two of using Input.MousePosition I hope the two towers will shoot at the mouse
        //transform.LookAt(Input.mousePosition, Camera.main.ScreenToWorldPoint(transform.position)); failed

        Vector3 turnTowards = Input.mousePosition;
        Quaternion lookRotation = Quaternion.identity;

        if (!right)
        {
            Vector3 direction = (turnTowards - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
        }
        else
        {
            Vector3 direction = (-turnTowards - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, -direction.y));
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);


        //can shoot
        if (Input.GetButtonDown("Fire1"))
        {
                Debug.Log("Fire1");
                Instantiate(bullet, transform.position, transform.rotation);
        }
            // can get killed by enemy

           
    }
}