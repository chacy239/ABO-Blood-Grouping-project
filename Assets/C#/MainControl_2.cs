using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl_2 : MonoBehaviour
{
    public Text tiptext;//������ʾ����
    private string tipstr;//��ʾ����������

    public GameObject kedu1;//����̶�UI1
    public GameObject kedu2;//����̶�UI2


    public GameObject yiyeqi1, yiyeqi2;

    public GameObject lixinjiUI;//���Ļ�����UI

    public Image lixinima;//���Ľ�����
    public GameObject shiji1,shiji2,shiji3;
    public GameObject ningjiaokaUI;//������UI

    void Start()
    {
        
    }

    public void ATip(int times,string str)
    {
        Invoke("Asettip", times);
        tipstr = str;
    }
    public void Asettip()
    {
        tiptext.text = tipstr;
    }

    public void Akedu1()
    {
        //����̶�1
        yiyeqi1.GetComponent<Animator>().enabled = true;
        yiyeqi1.GetComponent<BoxCollider>().enabled = false;
        kedu1.SetActive(false);
        ATip(22, "Add the red blood cell suspension to the corresponding column of the gel card");
        Invoke("Ashowkedu2", 22);
    }
    public void Ashowkedu2()
    {
        //��ʾ�̶�2��ģ��
        yiyeqi1.SetActive(false);
        yiyeqi2.SetActive(true);
    }

    public void Akedu2()
    {
        //����̶�2
        yiyeqi2.GetComponent<Animator>().enabled = true;
        yiyeqi2.GetComponent<BoxCollider>().enabled = false;
        kedu2.SetActive(false);
        ATip(17, "Put the gel card into the centrifuge and set the appropriate speed and time");
        Destroy(yiyeqi2, 17) ;
        Invoke("Ashijie2", 17);
    }
    public void Ashijie2()
    {
        shiji1.SetActive(false);
        shiji2.SetActive(true);
    }
    public void Alixinji()
    {
        //�������Ļ�
        lixinjiUI.SetActive(true);
    }
    public void Alixinbtn()
    {
        //�������Ļ�
        lixinjiUI.SetActive(false);
        lixinima.transform.parent.gameObject.SetActive(true);

    }
    public void AningjiaokaUI()
    {
        //��ʾ������UI

    }
    void Update()
    {
        if (lixinima.transform.parent.gameObject.activeInHierarchy)
        {
            lixinima.fillAmount += Time.deltaTime / 3;
            if (lixinima.fillAmount >= 1)
            {
                shiji3.SetActive(true);
                lixinima.transform.parent.gameObject.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ray01 = new Ray(Camera.main.transform.position, Vector3.forward);
            RaycastHit hit;
            //?��?????????????
            bool isCollider = Physics.Raycast(ray, out hit);
            //bool isCollider01= Physics.Raycast(Camera.main.transform.position, Vector3.forward, 
            //    10, LayerMask.GetMask("UI", "Enemy", "Player"));
            if (isCollider)
            {
                print(hit.collider.gameObject.name);

                if (hit.collider.gameObject.name == "Shiji")
                {
                    //˺������
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    ATip(5, "Add reagent red blood cells to each column of the gel card.");
                }
                if (hit.collider.gameObject.name == "yiyeqi1")
                {
                    //oѧ����ͨ���ϷŲ�����Drag-and-Drop�����Լ���ϸ����Reagent Red Cells��������֪��ԭ�ĺ�ϸ����Red Cells with Known Antigens�������������ĸ������С�
                    kedu1.SetActive(true);
                }
                if (hit.collider.gameObject.name == "yiyeqi2")
                {
                    //���Ʊ��õĺ�ϸ������Һ��Ѫ����Plasma���ֱ���뵽����������Ӧ����
                    kedu2.SetActive(true);
                }
                if (hit.collider.gameObject.name == "Shiji2")
                {
                    //�������������Ļ�
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    Invoke("Alixinji", 5);
                }
                if (hit.collider.gameObject.name == "Shiji3")
                {
                    //�������������Ļ�
                    ningjiaokaUI.SetActive(true);
                }
            }
        }


    }
}
