using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D me;
    private Renderer mRenderer;
    Stats stats;


    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Rigidbody2D>();
        mRenderer = GetComponent<Renderer>();
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        me.velocity = transform.right * stats.speed;
        if (!(mRenderer.isVisible))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D colission)
    {
        Debug.Log("HIT");
        Stats collider = colission.collider.GetComponent<Stats>();
        collider.HP=collider.HP-stats.strength;
        Destroy(gameObject);
    }


}