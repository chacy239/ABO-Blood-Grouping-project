using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook1 : MonoBehaviour {

	//�������ӽ��ƶ�
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	//�����ӽ�ת���ٶȣ��Լ���ת�������Χ
	public float sensitivityX = 15F;//����ת�����ٶ�
	public float sensitivityY = 15F;//����ת�����ٶ�

	public float minimumX = -360F;//��ת�����Ƕ�
	public float maximumX = 360F;//��ת�����Ƕ�

	public float minimumY = -60F;//��ת�����Ƕ�
	public float maximumY = 60F;//��ת�����Ƕ�

	float rotationY = 0F;

	void Update ()
	{

		if (axes == RotationAxes.MouseXAndY)
		{
			//����X���Y�ᶼ��ת��
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//��������ת�����ٶ�
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);//��������ת������ֵ

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);//��������ת��
		}
		else if (axes == RotationAxes.MouseX)
		{
			//ֻ��X��ת��
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			//ֻ��Y��ת��
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;////����ת�����ٶ�
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);//����ת������ֵ

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);//����ת��
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())//��ȡrigidbody���
			GetComponent<Rigidbody>().freezeRotation = true;
	}
}