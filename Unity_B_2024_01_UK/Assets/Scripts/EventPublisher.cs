using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    // Start is called before the first frame update
    public EventChannel eventChannel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))  //�����̽��ٸ� ���� �� �̺�Ʈ �߻�
        {
            eventChannel.RaiseEvent();
        }    
    }
}
