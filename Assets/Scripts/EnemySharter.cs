using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySharter : MonoBehaviour
{
    public GameObject thingToShart;
    Stats stats;
    public float enemiesPerSecond;
    public Transform enemyTarget;

    public int MaxNumberOfEnemiesSpawned;
    int enemy_shot;

    void Start()
    {
        stats = GetComponent<Stats>();
        InvokeRepeating("ShootBullet", 0, (1 / enemiesPerSecond));

    }

    // Update is called once per frame
    void Update()
    {
    }
    void ShootBullet()
    {
        if (enemy_shot<MaxNumberOfEnemiesSpawned)
        {
            GameObject bullet = (GameObject)Instantiate(thingToShart, transform.position, transform.rotation);
            Stats bullets = bullet.GetComponent<Stats>();
            Enemy enemy = bullet.GetComponent<Enemy>();
            bullets.speed = stats.speed;
            bullets.strength = stats.strength;
            enemy.player=enemyTarget;
            enemy_shot++;
        }
    }

}

