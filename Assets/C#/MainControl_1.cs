using HighlightingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl_1 : MonoBehaviour
{
    public GameObject Btn_Washing, Btn_Centrifugation,Btn_Supernatant,Btn_Create;
    public GameObject Tip_text;

    public Image Ima_Washing, Ima_Centrifugation, Ima_Supernatant;

    public GameObject Labels_Panel;//������

    public GameObject Labels_Create;//�������Թ�

    public GameObject Tube1,Tube2;

    void Start()
    {
        Btn_Washing.GetComponent<Button>().onClick.AddListener(AWashing);
        Btn_Centrifugation.GetComponent<Button>().onClick.AddListener(ACentrifugation);
        Btn_Supernatant.GetComponent<Button>().onClick.AddListener(ASupernatant);

        Btn_Create.GetComponent<Button>().onClick.AddListener(ACreate);
    }
    public void ATip(string str)
    {
        GameObject obj = Instantiate(Tip_text, Tip_text.transform.parent);
        obj.GetComponent<Text>().text = str;
        obj.SetActive(true);
        Destroy(obj, 2);
    }
    public void ACreate()
    {
        //�������Թ�
        Tube1.GetComponent<Collider>().gameObject.GetComponent<Animator>().enabled = true;
        Btn_Washing.SetActive(true);
        Labels_Create.gameObject.SetActive(false);
    }
    public void AWashing()
    {
        //�ڶ���ϴ��
        Btn_Washing.SetActive(false);
        Ima_Washing.gameObject.transform.parent.gameObject.SetActive(true);


    }
    public void ACentrifugation()
    {
        //离心机
        Btn_Centrifugation.SetActive(false);
       
        Tube1.GetComponent<Animator>().enabled = false;
        Tube1.SetActive(false);
        Tube2.SetActive(true);
        Invoke("ACentrifugation_2", 4);
    }
    public void ACentrifugation_2()
    {
        Ima_Centrifugation.gameObject.transform.parent.gameObject.SetActive(true);
    }



    public void ASupernatant()
    {
        //���Ĳ�ȥ������Һ
        Btn_Supernatant.SetActive(false);
        Ima_Supernatant.gameObject.transform.parent.gameObject.SetActive(true);


    }
    void Update()
    {
        if (Ima_Washing.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            Ima_Washing.fillAmount += Time.deltaTime/2;

            if (Ima_Washing.fillAmount >= 1)
            {
                Ima_Washing.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Washing completed");
                Btn_Centrifugation.SetActive(true);
            }
        }
        if (Ima_Centrifugation.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            //离心
            Ima_Centrifugation.fillAmount += Time.deltaTime/2;

            if (Ima_Centrifugation.fillAmount >= 1)
            {
                Ima_Centrifugation.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Centrifuge completed");
                Btn_Supernatant.SetActive(true);
                Tube1.SetActive(true);
                Tube2.SetActive(false);
            } 
        }
        if (Ima_Supernatant.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            Ima_Supernatant.fillAmount += Time.deltaTime / 2;

            if (Ima_Supernatant.fillAmount >= 1)
            {
                Ima_Supernatant.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Cleared supernatant");
                Labels_Panel.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ray01 = new Ray(Camera.main.transform.position, Vector3.forward);
            RaycastHit hit;
            //�ж��Ƿ���ײ������
            bool isCollider = Physics.Raycast(ray, out hit);
            //bool isCollider01= Physics.Raycast(Camera.main.transform.position, Vector3.forward, 
            //    10, LayerMask.GetMask("UI", "Enemy", "Player"));
            if (isCollider)
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "ѪҺƿ")
                {
                    //��һ��
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    hit.collider.gameObject.GetComponent<Highlighter>().enabled = false;
                    Btn_Washing.SetActive(true);
                }
            }
        }

       
    }
}
