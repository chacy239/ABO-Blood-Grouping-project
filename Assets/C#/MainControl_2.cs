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

    private List<SaveState> savePoints = new List<SaveState>(); // Save point list
    private int currentSaveIndex = -1; // Index of the current save point

    void Start()
    {

    }

    public void ATip(int times,string str)
    {
        Invoke("Asettip", times);
        tipstr = str;
        SaveProgress();
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

    // Save the current progress, including object position, status, etc.
    public void SaveProgress()
        {
            SaveState currentState = new SaveState
            {
                tipText = tiptext.text, // Save the tip text
                yiyeqi1Position = yiyeqi1.transform.position, // Save the position of yiyeqi1
                yiyeqi2Position = yiyeqi2.transform.position, // Save the position of yiyeqi2
                yiyeqi1Active = yiyeqi1.activeSelf, // Save the activation status of yiyeqi1
                yiyeqi2Active = yiyeqi2.activeSelf, // Save the activation status of yiyeqi2
                lixinjiUIActive = lixinjiUI.activeSelf, // Save the display state of the centrifuge UI
                lixinimaFillAmount = lixinima.fillAmount // Save the centrifuge progress bar
            };

            // Remove future storage points to ensure continuity of storage points
            if (currentSaveIndex < savePoints.Count - 1)
            {
                savePoints.RemoveRange(currentSaveIndex + 1, savePoints.Count - (currentSaveIndex + 1));
            }
            savePoints.Add(currentState); // Add the current state to the storage point list
            currentSaveIndex++;
            Debug.Log("Save point has been saved: ");
        }

        // Return to the previous storage point
        public void ReturnToPreviousSavePoint()
        {
            if (currentSaveIndex > 0)
            {
                currentSaveIndex--;
                SaveState previousState = savePoints[currentSaveIndex];

                //Restore prompt text
                tiptext.text = previousState.tipText;

                // Restore the location and status of yiyeqi1 and yiyeqi2
                yiyeqi1.transform.position = previousState.yiyeqi1Position;
                yiyeqi1.SetActive(previousState.yiyeqi1Active);
                yiyeqi2.transform.position = previousState.yiyeqi2Position;
                yiyeqi2.SetActive(previousState.yiyeqi2Active);

                // Restore the state of the centrifuge UI
                lixinjiUI.SetActive(previousState.lixinjiUIActive);
                lixinima.fillAmount = previousState.lixinimaFillAmount;

                Debug.Log("Return to the previous save point " );
            }
            else
            {
                Debug.Log("This is the first save point.");
            }
        }
    }

[System.Serializable]
public class SaveState
{
    public string tipText; // stored tip text
    public Vector3 yiyeqi1Position; // Save the position of yiyeqi1
    public Vector3 yiyeqi2Position; // Save the position of yiyeqi2
    public bool yiyeqi1Active; // Save the activation status of yiyeqi1
    public bool yiyeqi2Active; // Save the activation status of yiyeqi2
    public bool lixinjiUIActive; // Save the display status of the centrifuge UI
    public float lixinimaFillAmount; // Centrifuge progress bar
}
