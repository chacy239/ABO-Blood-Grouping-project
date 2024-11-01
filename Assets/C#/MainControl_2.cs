using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainControl_2 : MonoBehaviour
{
    public Text tiptext;//������ʾ����
    private string tipstr;//��ʾ����������

    public GameObject kedu1;//����̶�UI1
    public GameObject kedu2;//����̶�UI2
    public GameObject kedu3;//����̶�UI2
    public GameObject kedu4;//����̶�UI2


    public GameObject yiyeqi1, yiyeqi2;

    public GameObject lixinjiUI;//���Ļ�����UI

    public Image lixinima;//���Ľ�����
    public GameObject shiji1,shiji2,shiji3;
    public GameObject ningjiaokaUI;//������UI

    public Animator lixinjiani;


    public GameObject Arrow1, Arrow2, Arrow3, Arrow4, Arrow5, Arrow6, Arrow7;//��Һ������ʾ
    public TextToggleController textToggleController;
    public Button tutorialModeButton;
    public GameObject TipArea;

    public Button saveInterpretationButton; // Save the button explaining the input
    public InputField scaleQuantity1Input;
    public InputField scaleQuantity2Input;
    public InputField scaleQuantity3Input;
    public InputField scaleQuantity4Input;
    public InputField appropriateSpeedInput;
    public InputField appropriateTimeInput;
    public InputField interpretationInput; // Input box for entering experimental explanations

    private string csvFilePath; // Path to save CSV file

    private int currentStep = 0; // current step

    public GameObject shiguan1,shiguan2,shiguan3,shiguan4;//Ҫ���4���Թ�


    public GameObject yiyeqi_xitou;//��Һ����ͷ����
    public GameObject R_tip;//��ʾ��R

    public GameObject shiguanye1,shiguanye2,shiguanye3,shiguanye4;//�Թ����Һ��

    public GameObject finalResPanel;
    public GameObject fileEntryPanel;
    // data entry poins

    public Text studentName;
    public Text stuID;
    public Text time;

    public Text patientName;
    public Text patientDOB;
    public Text fileNumb;
    public Text ogBloodGrp;

    public Text stuFileNumb;
    public Text stuInput;

    public Ningjiaoka bldGrpScrpt;


    private int arrownum=0;
    void Start()
    {


        //Set file path
        csvFilePath = Application.persistentDataPath + "/ExperimentResult.csv";

        // Check if the CSV file exists, if not create it
        if (!File.Exists(csvFilePath))
        {
            CreateCSVFile();
        }

        //Set button click event

        tutorialModeButton.onClick.AddListener(() => ToggleTutorialMode(currentStep));

    }

    public void ToggleTutorialMode(int step)
    {
        textToggleController.ToggleTutorial(step);
    }

    private void CreateCSVFile()
    {
        using (StreamWriter writer = new StreamWriter(csvFilePath, false))
        {
            writer.WriteLine("Full Name,Date of Birth,Lab Number,Number of washed,Scale Quantity 1,Scale Quantity 2,Scale Quantity 3,Scale Quantity 4,Appropriate Speed,Appropriate Time,Interpretation");
        }
    }


    public void SaveExperimentData()
    {


        //    =========================================================================================
        fileEntryPanel.SetActive(false);
        finalResPanel.SetActive(true);
        for (int i = 0; i < finalResPanel.transform.childCount; i++)
        {
            finalResPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        
        studentName.text = PlayerPrefs.GetString("Name");
        stuID.text = PlayerPrefs.GetString("Id");
        time.text = GameObject.FindFirstObjectByType<TimeKeeper>().UpdateTimerText();

        patientName.text = UserDataManager.instance.GetFullName();
        patientDOB.text = UserDataManager.instance.GetDateOfBirth();
        fileNumb.text = UserDataManager.instance.GetLabNumber();
        ogBloodGrp.text = bldGrpScrpt.bloodGrp;

        stuFileNumb.text = bldGrpScrpt.fileNumb;
        stuInput.text = bldGrpScrpt.studentAns;



        ////////////////////////////////////////////////////////////////////////////////////////////

        // Get personal information (from UserDataManager)
        string fullName = UserDataManager.instance.GetFullName();
        string dateOfBirth = UserDataManager.instance.GetDateOfBirth();
        string labNumber = UserDataManager.instance.GetLabNumber();
        int cycleCount = UserDataManager.instance.GetCycleCount();

        // Get experimental data entered by the user
        string scaleQuantity1 = scaleQuantity1Input.text;
        string scaleQuantity2 = scaleQuantity2Input.text; 
        string scaleQuantity3 = scaleQuantity3Input.text;
        string scaleQuantity4 = scaleQuantity4Input.text;
        string appropriateSpeed = appropriateSpeedInput.text;
        string appropriateTime = appropriateTimeInput.text;
        string interpretation = interpretationInput.text;



        // Write all data to a CSV file
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            writer.WriteLine($"{fullName},{dateOfBirth},{labNumber},{cycleCount},{scaleQuantity1},{scaleQuantity2},{scaleQuantity3},{scaleQuantity4},{appropriateSpeed},{appropriateTime},{interpretation}");
        }


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
        ATip(22, "Add A-type red cell reagent to the first four columns of the gel card");
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


    /// <summary>
    /// // Game Ends Here ..............
    /// </summary>
    public void Alixinji()
    {
        //�������Ļ�
        lixinjiUI.SetActive(true);
        lixinjiani.SetBool("close", true);
        Debug.Log("Puru chalo .......................");
        // ///////////////////////////////////////// show the final result here ...
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

    public void Alixinend()
    {
        //���Ľ�����ȡ��������
        shiji3.SetActive(true);
    }

    public void AArrow1()
    {
        //��ʾ��Һ����ʾ,���õ�
        R_tip.SetActive(true);

        //���ص�һ������������
        shiji1.SetActive(false);
        shiji2.SetActive(true);
        // yiyeqi1.GetComponent<BoxCollider>().enabled = true;//������Һ��������
        //  Arrow1.SetActive(true);
    }
    public void AarrowControl()
    {
        arrownum++;
        yiyeqi_xitou.GetComponent<Animator>().enabled = false;
        yiyeqi_xitou.SetActive(false);

        //���Ƽ�ͷ����ʾ
        if (arrownum == 1)
        {
            ATip(5, "Add the patient's red blood cells to the gelcard");
            EndStep();
            currentStep = 2;
            shiguan1.GetComponent<BoxCollider>().enabled = true;
            shiguan1.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (arrownum == 2)
        {
            ATip(5, "Add the ABO A1 reagent to the gelcard");
            EndStep();
            currentStep = 4;
            shiguan2.GetComponent<BoxCollider>().enabled = true;
            shiguan2.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (arrownum == 3)
        {
            ATip(5, "Add the ABO B reagent to the gelcard");
            EndStep();
            currentStep = 6;
            shiguan3.GetComponent<BoxCollider>().enabled = true;
            shiguan3.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (arrownum == 4)
        {
            ATip(5, "Add the patient's plasma suspension to the gelcard");
            EndStep();
            currentStep = 8;
            shiguan4.GetComponent<BoxCollider>().enabled = true;
            shiguan4.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void Akedu()
    {
        kedu1.SetActive(false);
        Invoke("Aresxitou", 8);
        EndStep();
        shiguan1.GetComponent<BoxCollider>().enabled = false;
        shiguan1.GetComponent<Animator>().enabled = true;
        currentStep = 3;
        ATip(5, "Please press R to change the pipette tip");

    }


    public void NAkedu2()
    {
        kedu2.SetActive(false);
        Invoke("Aresxitou", 8);
        EndStep();
        shiguan2.GetComponent<BoxCollider>().enabled = false;
        shiguan2.GetComponent<Animator>().enabled = true;
        currentStep = 5;
        ATip(5, "Please press R to change the pipette tip");
    }

    public void NAkedu3()
    {
        kedu3.SetActive(false);
        Invoke("Aresxitou", 8);
        EndStep();
        shiguan3.GetComponent<BoxCollider>().enabled = false;
        shiguan3.GetComponent<Animator>().enabled = true;
        currentStep = 7;
        ATip(5, "Please press R to change the pipette tip");
    }

    public void NAkedu4()
    {
        kedu4.SetActive(false);
        Invoke("Aresxitou", 8);
        EndStep();
        shiguan4.GetComponent<BoxCollider>().enabled = false;
        shiguan4.GetComponent<Animator>().enabled = true;
        currentStep = 9;
        ATip(5, "Place the gel into the centrifuge");
    }
    public void Aresxitou()
    {
        //������ʾ��Ҫ��ͷ����Һ��
       


        if (arrownum == 1)
        {
            shiguanye1.SetActive(true);
        }
        if (arrownum == 2)
        {
        }
        if (arrownum == 3)
        {
        }
        if (arrownum == 4)
        {
            shiguanye4.SetActive(true);
            shiji2.GetComponent<BoxCollider>().enabled = true;
            return;
        }

        R_tip.SetActive(true);
        yiyeqi_xitou.SetActive(true);

    }


    void Update()
    {
        //��R��ͷ
        if (Input.GetKeyDown(KeyCode.R) && R_tip.activeInHierarchy&& !yiyeqi_xitou.GetComponent<Animator>().enabled)
        {
            EndStep();
            R_tip.SetActive(false);
            yiyeqi_xitou.GetComponent<Animator>().enabled = true;
            Invoke("AarrowControl", 3);
        }


        if (lixinima.transform.parent.gameObject.activeInHierarchy)
        {
            lixinima.fillAmount += Time.deltaTime / 3;
            if (lixinima.fillAmount >= 1)
            {
                shiji2.SetActive(false);
                lixinjiani.SetBool("close", false);
                Invoke("Alixinend", 1);
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
                    Arrow4.SetActive(false);
                    textToggleController.tipText.SetActive(false);
                    EndStep();
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    ATip(5, "Please press R to attach a tip to the pipette");
                    currentStep = 1;
                    Invoke("AArrow1", 5);
                }
                if (hit.collider.gameObject.name == "yiyeqi1")
                {
                    //�ڷ�Һ��װ����ͷ���Ƚ�A�͵ĺ�ϸ���Լ����뵽gel cardǰ���У�
                    kedu1.SetActive(true);
                    Arrow1.SetActive(false);
                    textToggleController.tipText.SetActive(false);
                }
                if (hit.collider.gameObject.name == "yiyeqi2")
                {
                    //��A1�У���ͷ�����������У�����A1��ϸ���Լ�������֮ǰ���ĵĻ���ѪҺ�Լ�
                    kedu2.SetActive(true);
                    Arrow2.SetActive(false);
                    textToggleController.tipText.SetActive(false);
                    currentStep = 3;
                }
                if (hit.collider.gameObject.name == "yiyeqi3")
                {
                    //��B�У���ͷ�����������У�����B��ϸ���Լ�������֮ǰ���ĵĻ���ѪҺ�Լ���
                    kedu2.SetActive(true);
                    Arrow3.SetActive(false);
                    textToggleController.tipText.SetActive(false);
                }

                if (hit.collider.gameObject.name == "yiyeqi4")
                {
                    //ȡ�����ߵ�Ѫ������Һ���Ҳ����е��롣
                    kedu2.SetActive(true);
                    Arrow4.SetActive(false);
                    textToggleController.tipText.SetActive(false);
                }


                if (hit.collider.gameObject.name == "Shiji2")
                {
                    //�������������Ļ�
                    Arrow3.SetActive(false);
                    textToggleController.tipText.SetActive(false);
                    EndStep();
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    Invoke("Alixinji", 5);
                    ATip(5, "Display the gel card results");
                }
                if (hit.collider.gameObject.name == "Shiji3")
                {
                    //��ʾ���������
                    ningjiaokaUI.SetActive(true);
                    gameObject.GetComponent<RigibodyMove>().enabled = false;
                    gameObject.GetComponent<MouseLook1>().enabled = false;
                }



                //4������
                if (hit.collider.gameObject.name == "shiguan1")
                {
                    kedu1.SetActive(true);
                }
                if (hit.collider.gameObject.name == "shiguan2")
                {
                    kedu2.SetActive(true);
                }
                if (hit.collider.gameObject.name == "shiguan3")
                {
                    kedu3.SetActive(true);
                }
                if (hit.collider.gameObject.name == "shiguan4")
                {
                    kedu4.SetActive(true);
                }

            }
        }


    }

    public void EndStep()
    {
        TipArea.SetActive(false); 
        Arrow1.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);
        Arrow4.SetActive(false);
        Arrow5.SetActive(false);
        Arrow6.SetActive(false);
        Arrow7.SetActive(false);

    }



}
