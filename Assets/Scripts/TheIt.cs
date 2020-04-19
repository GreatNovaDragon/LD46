using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheIt : MonoBehaviour
{
    Rigidbody2D body;
    public ProgressBar health;
    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        stats.HP=stats.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        health.maximum=stats.MaxHP;
        health.current=stats.HP;
    }

    bool isRunning = false;
    void OnCollisionEnter2D(Collision2D colission)
    {
        Debug.Log("HIT3");
        /* Stats collider = colission.collider.GetComponent<Stats>();
         collider.HP=collider.HP-stats.strength;
         Destroy(gameObject);*/

        if (isRunning) StopCoroutine("ReenableMovement");
        body.isKinematic = true;
        body.velocity = Vector3.zero;
        StartCoroutine("ReenableMovement");
    }

    IEnumerator ReenableMovement()
    {
        isRunning = true;
        yield return new WaitForSeconds(10);
        body.isKinematic = false;
        isRunning = false;
    }
}
