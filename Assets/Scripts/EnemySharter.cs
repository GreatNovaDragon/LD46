using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySharter : MonoBehaviour
{
    public GameObject thingToShart;
    Stats stats;
    public float enemies_per_Second;
    public Transform enemyTarget;


    void Start()
    {
        stats = GetComponent<Stats>();
        InvokeRepeating("ShootBullet", 0, (1 / enemies_per_Second));

    }

    // Update is called once per frame
    void Update()
    {
    }
    void ShootBullet()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 100)
        {
            GameObject bullet = (GameObject)Instantiate(thingToShart, transform.position, transform.rotation);
            Stats bullets = bullet.GetComponent<Stats>();
            Enemy enemy = bullet.GetComponent<Enemy>();
            bullets.speed = stats.speed;
            bullets.strength = stats.strength;
            Debug.Log(enemy.p);
            enemy.player=enemyTarget;
        }
    }

}

