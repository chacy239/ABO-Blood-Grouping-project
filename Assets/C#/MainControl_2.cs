using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl_2 : MonoBehaviour
{
    public Text tiptext;//顶部提示文字
    private string tipstr;//提示的文字内容

    public GameObject kedu1;//输入刻度UI1
    public GameObject kedu2;//输入刻度UI2


    public GameObject yiyeqi1, yiyeqi2;

    public GameObject lixinjiUI;//离心机设置UI

    public Image lixinima;//离心进度条
    public GameObject shiji1,shiji2,shiji3;
    public GameObject ningjiaokaUI;//凝胶卡UI

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
        //输入刻度1
        yiyeqi1.GetComponent<Animator>().enabled = true;
        yiyeqi1.GetComponent<BoxCollider>().enabled = false;
        kedu1.SetActive(false);
        ATip(22, "Add the red blood cell suspension to the corresponding column of the gel card");
        Invoke("Ashowkedu2", 22);
    }
    public void Ashowkedu2()
    {
        //显示刻度2的模型
        yiyeqi1.SetActive(false);
        yiyeqi2.SetActive(true);
    }

    public void Akedu2()
    {
        //输入刻度2
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
        //设置离心机
        lixinjiUI.SetActive(true);
    }
    public void Alixinbtn()
    {
        //操作离心机
        lixinjiUI.SetActive(false);
        lixinima.transform.parent.gameObject.SetActive(true);

    }
    public void AningjiaokaUI()
    {
        //显示凝胶卡UI

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
            //?ж?????????????
            bool isCollider = Physics.Raycast(ray, out hit);
            //bool isCollider01= Physics.Raycast(Camera.main.transform.position, Vector3.forward, 
            //    10, LayerMask.GetMask("UI", "Enemy", "Player"));
            if (isCollider)
            {
                print(hit.collider.gameObject.name);

                if (hit.collider.gameObject.name == "Shiji")
                {
                    //撕开凝胶
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    ATip(5, "Add reagent red blood cells to each column of the gel card.");
                }
                if (hit.collider.gameObject.name == "yiyeqi1")
                {
                    //o学生将通过拖放操作（Drag-and-Drop）将试剂红细胞（Reagent Red Cells，含有已知抗原的红细胞，Red Cells with Known Antigens）加入凝胶卡的各个柱中。
                    kedu1.SetActive(true);
                }
                if (hit.collider.gameObject.name == "yiyeqi2")
                {
                    //将制备好的红细胞悬浮液和血浆（Plasma）分别加入到凝胶卡的相应柱中
                    kedu2.SetActive(true);
                }
                if (hit.collider.gameObject.name == "Shiji2")
                {
                    //放置凝胶到离心机
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    Invoke("Alixinji", 5);
                }
                if (hit.collider.gameObject.name == "Shiji3")
                {
                    //放置凝胶到离心机
                    ningjiaokaUI.SetActive(true);
                }
            }
        }


    }
}
