using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ExItem
{
    public bool IsCollected;        //ȹ�濩��
}

public class ExCollectedSystem : MonoBehaviour
{

    public List<ExItem> collectedItem = new List<ExItem>();         //�÷��� �� ����Ʈ
    // Start is called before the first frame update
    void Start()
    {
        collectedItem.Add(new ExItem());
        collectedItem.Add(new ExItem());
        collectedItem[0].IsCollected = true;
        collectedItem[1].IsCollected = true;
        CheckAllItemsCollected();
    }

    void CheckAllItemsCollected()
    {
        if(collectedItem.All(item => item.IsCollected)) //��� �������� ���� �Ǿ����� �˻�
        {
            Debug.Log("All items collected");
        }
        else
        {
            Debug.Log("Not all items collected!");
        }
    }

    
}
