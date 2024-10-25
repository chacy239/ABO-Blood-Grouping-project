using HighlightingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl_1 : MonoBehaviour
{
    public GameObject Btn_Washing, Btn_Centrifugation,Btn_Supernatant,Btn_Create;
    public GameObject Btn_Label;
    public GameObject Tip_text;

    public Text tiptext;
    private string tipstr;
    public TextToggleController1 textToggleController1;

    public Image Ima_Washing, Ima_Centrifugation, Ima_Supernatant;

    public GameObject askWhatToDoTextObject; // Text object that asks the user what to do next
    public GameObject errorTextObject; // Text object that prompts the user to select an error
    public GameObject StepErrorTextObject;
    private GameObject correctButton;// Dynamically track the current correct button

    public GameObject Labels_Panel;//������

    public GameObject Labels_Create;//�������Թ�

    public GameObject Tube1,Tube2;

    public InputField fullNameInput;
    public InputField dateOfBirthInput;
    public InputField labNumberInput;
    public Button saveButton;

    private int currentStep = 1; // Track the current step
    private int supernatantCount = 0; // Counter, counts the number of times ASupernatant() is run
    private int cycleCount = 0; // Record how many complete experimental cycles have been completed


    void Start()
    {
        ATutorial("Preparation of Red Blood Cell Suspension");
        Btn_Washing.GetComponent<Button>().onClick.AddListener(() => {
            DisableAllButtons();
            CheckCorrectButton(Btn_Washing, AWashing); 
            Invoke("EnableAllButtons", 2); 
        });
        Btn_Centrifugation.GetComponent<Button>().onClick.AddListener(() => {
            DisableAllButtons(); 
            CheckCorrectButton(Btn_Centrifugation, ACentrifugation);
            Invoke("EnableAllButtons", 4); 
        });
        Btn_Supernatant.GetComponent<Button>().onClick.AddListener(() => {
            DisableAllButtons(); 
            CheckCorrectButton(Btn_Supernatant, ASupernatant); 
            Invoke("EnableAllButtons", 2); 
        });
        Btn_Label.GetComponent<Button>().onClick.AddListener(() => {
            DisableAllButtons(); 
            CheckLabels(); 
            Invoke("EnableAllButtons", 2); 
        });
        Btn_Create.GetComponent<Button>().onClick.AddListener(ACreate);

        //Set the click event of the save button to save personal data
        saveButton.onClick.AddListener(SaveUserData);

        // Initially hide error buttons and question text
        askWhatToDoTextObject.gameObject.SetActive(false);
        errorTextObject.gameObject.SetActive(false);
        HideAllButtons();
        ATutorial("Please Washing");
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
        ATutorial("Please Centrifugation");
        textToggleController1.tipText.SetActive(false);
        currentStep = 1;
        ShowStepButtons();
        askWhatToDoTextObject.SetActive(true);

    }
    public void AWashing()
    {
        //�ڶ���ϴ��
        HideAllButtons();
        Ima_Washing.gameObject.transform.parent.gameObject.SetActive(true);
       
    }

    public void ACentrifugation()
    {
        //离心机
        HideAllButtons();
        Tube1.GetComponent<Animator>().enabled = false;
        textToggleController1.tipText.SetActive(false);
        Tube1.SetActive(false);
        Tube2.SetActive(true);
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
        supernatantCount++;
        cycleCount++;
        Btn_Supernatant.SetActive(false);
        Ima_Supernatant.gameObject.transform.parent.gameObject.SetActive(true);
    }


    public void ShowErrorPanel()
    {
        errorTextObject.gameObject.SetActive(true);
        Invoke("HideErrorMessage", 2);
    }

    private void HideErrorMessage()
    {
        errorTextObject.gameObject.SetActive(false);  
    }

    private void ShowStepButtons()
    {
        HideAllButtons(); // Hide all buttons first

        if (supernatantCount >= 3)
        {
            // When ASupernatant completes three times, allow the Labels_Panel button to appear
            Btn_Label.SetActive(true);
        }

        switch (currentStep)
        {
            case 1:
                // The first step: washing, Btn_Washing is the correct button
                Ima_Washing.fillAmount = 0;
                Ima_Centrifugation.fillAmount = 0;
                Ima_Supernatant.fillAmount = 0;

                Btn_Washing.SetActive(true);
                Btn_Centrifugation.SetActive(true);
                Btn_Supernatant.SetActive(true);
                correctButton = Btn_Washing; // This step Btn_Washing is correct
                break;
            case 2:
                // Step 2: Centrifugation, Btn_Centrifugation is the correct button
                Btn_Washing.SetActive(true);
                Btn_Centrifugation.SetActive(true);
                Btn_Supernatant.SetActive(true);
                correctButton = Btn_Centrifugation; // This step Btn_Centrifugation is correct
                break;
            case 3:
                // Step 3: Remove the supernatant, Btn_Supernatant is the correct button
                Btn_Washing.SetActive(true);
                Btn_Centrifugation.SetActive(true);
                Btn_Supernatant.SetActive(true);
                correctButton = Btn_Supernatant; // This step Btn_Supernatant is correct
                break;
        }
    }

    // Check whether the pressed button is the correct button and perform the corresponding operation based on the result
    private void CheckCorrectButton(GameObject clickedButton, System.Action correctAction)
    {
        if (clickedButton == correctButton)
        {
            // Correct button, execute the corresponding method
            correctAction.Invoke();
            currentStep++; // Go to the next step
            if (currentStep <= 3)
            {
                ShowStepButtons(); // Update button display
            }
            else
            {
                HideAllButtons(); // Hide all buttons when finished
            }
        }
        else
        {
            // Error button, displays error message
            ShowErrorPanel();
        }
    }
    private void CheckLabels()
    {
        if (supernatantCount >= 3 && currentStep == 1)
        {
            //Click correctly Labels_Panel
            Labels_Panel.SetActive(true); // Hide Labels_Panel once used
        }
        else
        {
            // Error: Labels_Panel was pressed not completed three times or when step is not at 1
            ShowStepErrorText();
        }
    }

    void DisableAllButtons()
    {
        Btn_Washing.GetComponent<Button>().interactable = false;
        Btn_Centrifugation.GetComponent<Button>().interactable = false;
        Btn_Supernatant.GetComponent<Button>().interactable = false;
        Btn_Label.GetComponent<Button>().interactable = false;
        Btn_Create.GetComponent<Button>().interactable = false;
    }

    void EnableAllButtons()
    {
        Btn_Washing.GetComponent<Button>().interactable = true;
        Btn_Centrifugation.GetComponent<Button>().interactable = true;
        Btn_Supernatant.GetComponent<Button>().interactable = true;
        Btn_Label.GetComponent<Button>().interactable = true;
        Btn_Create.GetComponent<Button>().interactable = true;
    }

    private void HideAllButtons()
    {
        Btn_Washing.SetActive(false); // Hide wash button
        Btn_Centrifugation.SetActive(false); //Hide the centrifugation button
        Btn_Supernatant.SetActive(false); //Hide the supernatant removal button
        Btn_Label.SetActive(false);
    }


    private void ShowStepErrorText()
    {
        StepErrorTextObject.SetActive(true); 
        Invoke("HideStepErrorText", 2);      
    }

    private void HideStepErrorText()
    {
        StepErrorTextObject.SetActive(false);  
    }

    public void SaveUserData()
    {
        string fullName = fullNameInput.text;
        string dateOfBirth = dateOfBirthInput.text;
        string labNumber = labNumberInput.text;

        // Call UserDataManager to save personal data
        UserDataManager.instance.SaveUserData(fullName, dateOfBirth, labNumber, cycleCount);


        ATip("Personal information saved!");
    }



    void Update()
    {
        if (Ima_Washing.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            HideAllButtons();
            textToggleController1.tipText.SetActive(false);
            askWhatToDoTextObject.gameObject.SetActive(false);
            Ima_Washing.fillAmount += Time.deltaTime/2;

            if (Ima_Washing.fillAmount >= 1)
            {
                Ima_Washing.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Washing completed");
                Btn_Centrifugation.SetActive(true);
                ATutorial("Please remove the supernatant");
                currentStep = 2;
                ShowStepButtons();
                askWhatToDoTextObject.SetActive(true); 

            }
        }
        if (Ima_Centrifugation.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            //离心
            HideAllButtons();
            textToggleController1.tipText.SetActive(false);
            askWhatToDoTextObject.gameObject.SetActive(false);
            Ima_Centrifugation.fillAmount += Time.deltaTime/2;

            if (Ima_Centrifugation.fillAmount >= 1)
            {
                Ima_Centrifugation.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Centrifuge completed");
                Btn_Supernatant.SetActive(true);
                ATutorial("Please repeat the above steps at least three times");
                currentStep = 3;
                ShowStepButtons();
                askWhatToDoTextObject.SetActive(true);
                Tube1.SetActive(true);
                Tube2.SetActive(false);

            } 
        }
        if (Ima_Supernatant.gameObject.transform.parent.gameObject.activeInHierarchy)
        {
            HideAllButtons();
            textToggleController1.tipText.SetActive(false);
            askWhatToDoTextObject.gameObject.SetActive(false);
            Ima_Supernatant.fillAmount += Time.deltaTime / 2;

            if (Ima_Supernatant.fillAmount >= 1)
            {
                Ima_Supernatant.gameObject.transform.parent.gameObject.SetActive(false);
                ATip("Cleared supernatant");
                currentStep = 1;
                ShowStepButtons();
                askWhatToDoTextObject.SetActive(true);
                ATutorial("Please Centrifugation");
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
