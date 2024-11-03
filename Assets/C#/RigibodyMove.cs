using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyMove : MonoBehaviour
{
    private float MoveSpeed = 1.5f;
    private float jumpcd;
    private Camera Cam;
    void Start()
    {
        Cam=Camera.main;
    }
    void Update()
    {

        if (Input.GetMouseButton(2) && Cam.fieldOfView>25)
        {
            Cam.fieldOfView -= 1f;
        }
        if (!Input.GetMouseButton(2) && Cam.fieldOfView < 50)
        {
            Cam.fieldOfView += 1f;
        }
        if (jumpcd < 2)
        {
            jumpcd += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpcd > 1)
        {
            jumpcd = 0;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 150);
        }
        //如果按下W或上方向键 If you press the W or up arrow key
        if (Input.GetKey(KeyCode.W))
        {
            //向前移动 forward motion
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //向后移动 backward
            this.transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //按上箭头增加移速 Press the up arrow to increase movement speed
            MoveSpeed += 2;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //按下箭头降低移速 Press the arrows to decrease your movement speed.
            MoveSpeed -= 2;
        }

        //如果按下A或左方向键 If you press A or the left arrow key
        if (Input.GetKey(KeyCode.A))
        {
            //向左移动 turn left
            this.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //向右移动 right-hand side
            this.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
    }
}
