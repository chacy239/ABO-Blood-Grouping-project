using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook1 : MonoBehaviour {

	//鼠标控制视角移动
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	//设置视角转动速度，以及能转动的最大范围
	public float sensitivityX = 15F;//左右转动的速度
	public float sensitivityY = 15F;//上下转动的速度

	public float minimumX = -360F;//左转的最大角度
	public float maximumX = 360F;//右转的最大角度

	public float minimumY = -60F;//下转的最大角度
	public float maximumY = 60F;//上转的最大角度

	float rotationY = 0F;

	void Update ()
	{

		if (axes == RotationAxes.MouseXAndY)
		{
			//设置X轴和Y轴都能转动
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//上下左右转动的速度
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);//上下左右转动的数值

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);//上下左右转动
		}
		else if (axes == RotationAxes.MouseX)
		{
			//只能X轴转动
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			//只能Y轴转动
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;////上下转动的速度
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);//上下转动的数值

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);//上下转动
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())//获取rigidbody组件
			GetComponent<Rigidbody>().freezeRotation = true;
	}
}