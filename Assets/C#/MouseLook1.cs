using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook1 : MonoBehaviour {

    //�������ӽ��ƶ� Mouse control to move the viewpoint
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

    //�����ӽ�ת���ٶȣ��Լ���ת�������Χ Set the viewpoint rotation speed and the maximum range of rotation.
    public float sensitivityX = 15F;//����ת�����ٶ� Speed of rotation from side to side
    public float sensitivityY = 15F;//����ת�����ٶ� Speed of up and down rotation

    public float minimumX = -360F;//��ת�����Ƕ� Maximum angle of left turn
    public float maximumX = 360F;//��ת�����Ƕ� Maximum angle of right turn

    public float minimumY = -60F;//��ת�����Ƕ� Maximum angle of downward rotation
    public float maximumY = 60F;//��ת�����Ƕ� Maximum angle of upward rotation

    float rotationY = 0F;

	void Update ()
	{
		if (Input.GetMouseButton(1))
		{
            if (axes == RotationAxes.MouseXAndY)
            {
                //����X���Y�ᶼ��ת�� Set both X and Y axis to rotate
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//��������ת�����ٶ� Up and down, left and right rotation speed
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//��������ת������ֵ Up and down, left and right rotation values

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);//��������ת�� Turn up, down, left, right
            }
            else if (axes == RotationAxes.MouseX)
            {
                //ֻ��X��ת�� X-axis rotation only
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                //ֻ��Y��ת��  Y-axis rotation only
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;////����ת�����ٶ� Speed of up and down rotation
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//����ת������ֵ Value of up and down rotation

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);//����ת�� turn
            }
        }

		
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())//��ȡrigidbody��� Get the rigidbody component
            GetComponent<Rigidbody>().freezeRotation = true;
	}
}