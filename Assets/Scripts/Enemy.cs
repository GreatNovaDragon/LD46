using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D body;
    public Transform player;
    Transform enemy;
    Stats stats;
    ProgressBar HP;
    public string p = "Poop";

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        enemy = GetComponent<Transform>();
       /* if (player == null)
        {
            player = GameObject.Find("TheIt").GetComponent(typeof(Transform)) as Transform;
        } */
        HP = GetComponentInChildren(typeof(ProgressBar)) as ProgressBar;
        HP.maximum = stats.MaxHP;

    }

    // Update is called once per frame
    void Update()
    {
        enemy.position = Vector2.MoveTowards(enemy.position, player.position, stats.speed * Time.deltaTime);
        if (stats.HP <= 0)
        { Destroy(gameObject); }

        float AngleRad = Mathf.Atan2(player.position.y - this.transform.position.y, player.position.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        HP.current = stats.HP;
        if (body.velocity.magnitude > stats.speed) { body.velocity = Vector3.zero; }
    }
    void OnCollisionEnter2D(Collision2D colission)
    {

        Debug.Log("HIT3");
        if (colission.collider.tag != "Enemy")
        {
            Stats collider = colission.gameObject.GetComponent<Stats>();
            collider.HP = collider.HP - stats.strength;
        }

    }
    void OnColissionStay2D(Collision2D col)
    {
        Debug.Log("HIT4");
        Stats collider = col.gameObject.GetComponent<Stats>();
        collider.HP = collider.HP - stats.strength;
    }




}

