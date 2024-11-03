using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook1 : MonoBehaviour {

    //鼠标控制视角移动 Mouse control to move the viewpoint
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

    //设置视角转动速度，以及能转动的最大范围 Set the viewpoint rotation speed and the maximum range of rotation.
    public float sensitivityX = 15F;//左右转动的速度 Speed of rotation from side to side
    public float sensitivityY = 15F;//上下转动的速度 Speed of up and down rotation

    public float minimumX = -360F;//左转的最大角度 Maximum angle of left turn
    public float maximumX = 360F;//右转的最大角度 Maximum angle of right turn

    public float minimumY = -60F;//下转的最大角度 Maximum angle of downward rotation
    public float maximumY = 60F;//上转的最大角度 Maximum angle of upward rotation

    float rotationY = 0F;

	void Update ()
	{
		if (Input.GetMouseButton(1))
		{
            if (axes == RotationAxes.MouseXAndY)
            {
                //设置X轴和Y轴都能转动 Set both X and Y axis to rotate
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//上下左右转动的速度 Up and down, left and right rotation speed
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//上下左右转动的数值 Up and down, left and right rotation values

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);//上下左右转动 Turn up, down, left, right
            }
            else if (axes == RotationAxes.MouseX)
            {
                //只能X轴转动 X-axis rotation only
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                //只能Y轴转动  Y-axis rotation only
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;////上下转动的速度 Speed of up and down rotation
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//上下转动的数值 Value of up and down rotation

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);//上下转动 turn
            }
        }

		
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())//获取rigidbody组件 Get the rigidbody component
            GetComponent<Rigidbody>().freezeRotation = true;
	}
}