using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamManager : MonoBehaviour 
{
    public GameData gameData;
    void Start()
    {


        //���۽� GameData�� ������ Debug.Log�� �����ش�.
        Debug.Log("Game Name : " + gameData.gameName);
        Debug.Log("Game Score : " + gameData.gameScore);
        Debug.Log("is Game Active : " + gameData.isGameActive);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
