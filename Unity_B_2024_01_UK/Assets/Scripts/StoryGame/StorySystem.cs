using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       //UI ���
using System;               //���ڿ� ���� �ϱ� ���� ���
using STORYGAME;



public class StorySystem : MonoBehaviour
{
    public static StorySystem instance;             //�̱���

    public StoryModel currentStoryModel;

    public enum TEXTSYSTEM
    {
        NONE,
        DOING,
        SELECT,
        DONE
    }

    public float delay = 0.1f;                  //���ڰ� ��Ÿ���µ� �ɸ��� �ð�
    public string fullText;                     //��ü ǥ���� �ؽ�Ʈ
    public string currentText = "";             //������� ǥ�õ� �ؽ�Ʈ
    public Text textCompont;                    //�ؽ�Ʈ ������Ʈ
    public Text storyIndex;                     //story ��ȣ
    public Image imageComponent;                //������ �̹���

    public Button[] buttonWay = new Button[3];  //������ ��ư
    public Text[] buttonWayText = new Text[3];  //��ư �ؽ�Ʈ

    TEXTSYSTEM textSystem = TEXTSYSTEM.NONE;



    public void Awake()
    {
        instance = this;
    }
    
    


    private void Start()
    {
        for(int i = 0; i < buttonWay.Length; i++)
        {
            int wayIndex = i;       //Ŭ����(colsure) ���� �ذ� �ϱ� ���� ���� ����
            //Ŭ���� ���� -> ���ٽ� �Ǵ� �͸� �Լ��� �ܺ� ������ ĸó�� �� �߻� �ϴ� ����
            buttonWay[i].onClick.AddListener(() => OnWayClick(wayIndex));
        }

        StoryModelInit();
        StartCoroutine(ShowText());
    }

    public void StoryModelInit()            //�޾ƿ� �� ������ ����
    {
        fullText = currentStoryModel.storyText;
        storyIndex.text = currentStoryModel.storyNumber.ToString();

        for (int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWayText[i].text = currentStoryModel.options[i].buttonText;
        }
    }

    public void CoShowText()
    {
        StoryModelInit();               //�� Init
        ResetShow();                    //����
        StartCoroutine(ShowText());
    }

    public void ResetShow()
    {
        textCompont.text = "";

        for(int i = 0; i < buttonWay.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(false);
        }
    }

    IEnumerator ShowText()
    {
        textSystem = TEXTSYSTEM.DOING;
        if (currentStoryModel.MainImage != null)
        {
            //Texture2D -> Sprite�� ��ȯ
            Rect rect = new Rect(0, 0, currentStoryModel.MainImage.width, currentStoryModel.MainImage.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);        //��������Ʈ�� ��(�߽�) ����
            Sprite sprite = Sprite.Create(currentStoryModel.MainImage, rect, pivot);

            imageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("Texture�� ������ �� �����ϴ�.");
        }

        for(int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);                 //���ڿ� 0���� i���� �����ش�.
            textCompont.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        for(int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        textSystem = TEXTSYSTEM.NONE;
    }

    public void OnWayClick(int index)           //��ư ������ ȣ�� �Ǵ� �Լ�
    {
        if (textSystem == TEXTSYSTEM.DOING)
            return;

        Debug.Log("OnWayClick : " + index);

        bool CheckEventTypeNone = false;            //�⺻������ None �϶��� ���� �Ǵ� ���н� �ٽ� �Լ� ȣ��Ǵ°��� ����
        StoryModel playStoryMode = currentStoryModel;

        if(playStoryMode.options[index].eventCheck.type == StoryModel.EventCheck.EventType.NONE)
        {
            for (int i = 0; i < playStoryMode.options[index].eventCheck.successResult.Length; i++)
            {
                GameSystem.Instance.ApplyChoice(currentStoryModel.options[index].eventCheck.successResult[i]);
                CheckEventTypeNone = true;
            }
        }
    }      
}
