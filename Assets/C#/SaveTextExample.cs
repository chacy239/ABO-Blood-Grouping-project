using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveTextExample : MonoBehaviour
{
    public InputField input1, input2;
    public void CreateAndSaveTextFile(string fileName, string content)
    {
        // ...................................................................................................

        string path = Path.Combine(System.Environment.CurrentDirectory, fileName);
        File.WriteAllText(path, content);
        Debug.Log("文件保存成功：" + path);
    }
    void Start()
    {

    }
    public void Acreate()
    {
        // string folderPath = "C:/MyTextFiles"; // 文件夹路径 Folder Path
        string fileName = input1.text+ ".txt"; // 文件名 filename
        string textContent = input2.text; // 文件内容 Contents of the document


        TimeKeeper timewatch = GameObject.Find("TimeClaculator").GetComponent<TimeKeeper>();


        // 确保文件夹存在 Make sure the folder exists
        if (!Directory.Exists(System.Environment.CurrentDirectory))
        {
            Directory.CreateDirectory(System.Environment.CurrentDirectory);
        }

        // 创建并保存文件 Creating and saving files
        CreateAndSaveTextFile(fileName, textContent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
