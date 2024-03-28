using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;    //JSON ����ȭ�� ���� ��Ű��    
using UnityEngine;

public class ExJsonData : MonoBehaviour
{
    string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "�÷��̾� 1";
            playerData.playerLevel = 1;
            playerData.items.Add("��1");
            playerData.items.Add("����1");
            SaveData(playerData);

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            for (int i = 0; i < playerData.items.Count; i++)
            {
                Debug.Log(playerData.items[i]);
                
            }
        }
    }

    void SaveData(PlayerData data)
    {
        //JSOn ����ȭ
        string jsonData = JsonConvert.SerializeObject(data);
        //���� ����
        File.WriteAllText(filePath, jsonData);
    }

    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            //���Ͽ��� ������ �б�
            string jsonData = File.ReadAllText(filePath);
            
            //JSON ������ȭ
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        else
        {
            return null;
        }
    }
}
