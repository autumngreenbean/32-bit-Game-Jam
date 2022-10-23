using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject m_enemy;
    public float timer = 0;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer % 10 == 0)
        {
            Instantiate(m_enemy, Enemy.transform);
        }
    }
}
