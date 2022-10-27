using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject new_enemy;
    public float timer = 0;
    public GameObject player;
    public GameObject EnemyFather;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyFather = GameObject.FindGameObjectWithTag("EnemyNest");
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Debug.Log(Enemy.name);
        if (timer < 0)
        {
            timer = 10;
            //Debug.Log(Enemy.name);
            Vector3 EnemyNest= player.transform.position;
            EnemyNest.x -= 15;
            GameObject enemyObj = Instantiate(new_enemy, EnemyNest, Quaternion.identity);
            enemyObj.AddComponent<EnemyController>();
            enemyObj.transform.parent = EnemyFather.transform;
        }
    }
}
