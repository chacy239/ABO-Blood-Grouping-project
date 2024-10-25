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
        string path = Path.Combine(System.Environment.CurrentDirectory, fileName);
        File.WriteAllText(path, content);
        Debug.Log("文件保存成功：" + path);
    }
    void Start()
    {

    }
    public void Acreate()
    {
       // string folderPath = "C:/MyTextFiles"; // 文件夹路径
        string fileName = input1.text+ ".txt"; // 文件名
        string textContent = input2.text; // 文件内容

        // 确保文件夹存在
        if (!Directory.Exists(System.Environment.CurrentDirectory))
        {
            Directory.CreateDirectory(System.Environment.CurrentDirectory);
        }

        // 创建并保存文件
        CreateAndSaveTextFile(fileName, textContent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
