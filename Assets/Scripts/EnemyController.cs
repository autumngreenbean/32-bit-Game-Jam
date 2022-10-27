using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 faceAt;
    public float speed; // the speed of enemy
    public int damage; // every object have different damage
    public GameObject player;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 0.1f;
        damage = 40;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);

        //calculate direction
        faceAt = player.transform.position - transform.position;

        //attack range
        if (faceAt.magnitude <= 10)
            transform.Translate(speed * Time.deltaTime * faceAt, Space.World);

    }

    public int getDamage()
    {
        return damage;
    }

    public float getSpeed()
    {
        return speed;
    }

    /* written in player
    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
    }
    */

}
