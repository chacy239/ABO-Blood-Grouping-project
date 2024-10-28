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
        Debug.Log("�ļ�����ɹ���" + path);
    }
    void Start()
    {

    }
    public void Acreate()
    {
       // string folderPath = "C:/MyTextFiles"; // �ļ���·��
        string fileName = input1.text+ ".txt"; // �ļ���
        string textContent = input2.text; // �ļ�����

        // ȷ���ļ��д���
        if (!Directory.Exists(System.Environment.CurrentDirectory))
        {
            Directory.CreateDirectory(System.Environment.CurrentDirectory);
        }

        // �����������ļ�
        CreateAndSaveTextFile(fileName, textContent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
