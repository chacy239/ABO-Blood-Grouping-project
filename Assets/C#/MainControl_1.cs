using HighlightingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl_1 : MonoBehaviour
{
    public GameObject Btn_Washing, Btn_Centrifugation,Btn_Supernatant,Btn_Create;
    public GameObject Tip_text;

    public Text tiptext;
    private string tipstr;

    public Image Ima_Washing, Ima_Centrifugation, Ima_Supernatant;

    public GameObject ErrorBtn_Washing1, ErrorBtn_Washing2; // Error option button for Washing
    public GameObject ErrorBtn_Centrifugation1, ErrorBtn_Centrifugation2; // Error option button for Centrifugation
    public GameObject ErrorBtn_Supernatant1, ErrorBtn_Supernatant2; // Error option button for Remove Supernatant

    public GameObject askWhatToDoTextObject; // Text object that asks the user what to do next
    public GameObject errorTextObject; // Text object that prompts the user to select an error

    public GameObject Labels_Panel;//������

    public GameObject Labels_Create;//�������Թ�

    public GameObject Tube1,Tube2;

    public InputField fullNameInput;
    public InputField dateOfBirthInput;
    public InputField labNumberInput;
    public Button saveButton;


    void Start()
    {
        ATutorial("Preparation of Red Blood Cell Suspension");
        Btn_Washing.GetComponent<Button>().onClick.AddListener(AWashing);
        Btn_Centrifugation.GetComponent<Button>().onClick.AddListener(ACentrifugation);
        Btn_Supernatant.GetComponent<Button>().onClick.AddListener(ASupernatant);

        Btn_Create.GetComponent<Button>().onClick.AddListener(ACreate);

        //Set the click event of the save button to save personal data
        saveButton.onClick.AddListener(SaveUserData);

        // Initially hide error buttons and question text
        askWhatToDoTextObject.gameObject.SetActive(false);
        errorTextObject.gameObject.SetActive(false);
        HideErrorButtons();
        ATutorial("Washing");
    }

    public void ATutorial(string str)
    {
        AsetTutorial();
        tipstr = str;
    }
    public void AsetTutorial()
    {
        tiptext.text = tipstr;
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
        ATutorial("Centrifugation");
        ShowErrorButtons(ErrorBtn_Washing1, ErrorBtn_Washing2);
        askWhatToDoTextObject.SetActive(true); 

        // Add listeners for error buttons
        ErrorBtn_Washing1.GetComponent<Button>().onClick.AddListener(ShowErrorPanel);
        ErrorBtn_Washing2.GetComponent<Button>().onClick.AddListener(ShowErrorPanel);
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
        HideErrorButtons();
        askWhatToDoTextObject.gameObject.SetActive(false);
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

    public void ShowErrorPanel()
    {
        errorTextObject.gameObject.SetActive(true);
        Invoke("HideErrorMessage", 2);
    }

    public void HideErrorMessage()
    {
        errorTextObject.gameObject.SetActive(false); // Hide the error text object
    }

    void HideErrorButtons()
    {
        // Hide all error buttons
        ErrorBtn_Washing1.SetActive(false);
        ErrorBtn_Washing2.SetActive(false);
        ErrorBtn_Centrifugation1.SetActive(false);
        ErrorBtn_Centrifugation2.SetActive(false);
        ErrorBtn_Supernatant1.SetActive(false);
        ErrorBtn_Supernatant2.SetActive(false);
    }

    void ShowErrorButtons(GameObject errorBtn1, GameObject errorBtn2)
    {
        HideErrorButtons(); // Hide any other error buttons that might be active
        errorBtn1.SetActive(true);
        errorBtn2.SetActive(true);
    }

    public void SaveUserData()
    {
        string fullName = fullNameInput.text;
        string dateOfBirth = dateOfBirthInput.text;
        string labNumber = labNumberInput.text;

        // Call UserDataManager to save personal data
        UserDataManager.instance.SaveUserData(fullName, dateOfBirth, labNumber);

        ATip("Personal information saved!");
    }


    void Update()
    {
        if (Ima_Washing.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            HideErrorButtons();
            askWhatToDoTextObject.gameObject.SetActive(false);
            Ima_Washing.fillAmount += Time.deltaTime/2;

            if (Ima_Washing.fillAmount >= 1)
            {
                Ima_Washing.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Washing completed");
                Btn_Centrifugation.SetActive(true);
                ATutorial("Remove Supernatant");
                ShowErrorButtons(ErrorBtn_Centrifugation1, ErrorBtn_Centrifugation2);
                askWhatToDoTextObject.SetActive(true); 

                ErrorBtn_Centrifugation1.GetComponent<Button>().onClick.AddListener(ShowErrorPanel);
                ErrorBtn_Centrifugation2.GetComponent<Button>().onClick.AddListener(ShowErrorPanel);
            }
        }
        if (Ima_Centrifugation.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            //离心
            HideErrorButtons();
            askWhatToDoTextObject.gameObject.SetActive(false);
            Ima_Centrifugation.fillAmount += Time.deltaTime/2;

            if (Ima_Centrifugation.fillAmount >= 1)
            {
                Ima_Centrifugation.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Centrifuge completed");
                Btn_Supernatant.SetActive(true);
                ATutorial("Remove Supernatant");
                ShowErrorButtons(ErrorBtn_Supernatant1, ErrorBtn_Supernatant2);
                askWhatToDoTextObject.SetActive(true);
                Tube1.SetActive(true);
                Tube2.SetActive(false);

                ErrorBtn_Supernatant1.GetComponent<Button>().onClick.AddListener(ShowErrorPanel);
                ErrorBtn_Supernatant2.GetComponent<Button>().onClick.AddListener(ShowErrorPanel);
            } 
        }
        if (Ima_Supernatant.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            HideErrorButtons();
            askWhatToDoTextObject.gameObject.SetActive(false);
            Ima_Supernatant.fillAmount += Time.deltaTime / 2;

            if (Ima_Supernatant.fillAmount >= 1)
            {
                Ima_Supernatant.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Cleared supernatant");
                Labels_Panel.SetActive(true);
                ATutorial("Remove Supernatant");
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
