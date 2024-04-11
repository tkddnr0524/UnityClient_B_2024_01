using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExEnemyManager : MonoBehaviour
{

    public List<ExEnemy> enemies = new List<ExEnemy>();


    // Start is called before the first frame update
    void Start()
    {

        //�������� ���� ������� �� ĳ���� ����
        var sortedEnemies = enemies.OrderBy(enemy => enemy.damage);

        foreach (var enemy in sortedEnemies)
        {
            Debug.Log("Sorted Enemy : " + enemy.gameObject.name + "Damage : " + enemy.damage);
        }

        //Ư�� �Ÿ� �̳��� �� ĳ���� ����
        float maxDistance = 10f;
        var closeEnemies = enemies.Where(enemy => Vector3.Distance(enemy.transform.position, transform.position) < maxDistance);

        foreach (var enemy in closeEnemies)
        {
            Debug.Log("Close Enemies : " + enemy.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
