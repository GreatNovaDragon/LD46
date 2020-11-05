using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    Camera cam;
    Transform my;
    Stats stats;
    // Start is called before the first frame update
    public GameObject HPBar;
    ProgressBar HPprog;
    Text HPText;
    void Start()
    {
        cam = Camera.main;
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        HPprog = HPBar.GetComponent(typeof(ProgressBar)) as ProgressBar;
        HPText = HPBar.GetComponentInChildren(typeof(Text)) as Text;
    }

    // Update is called once per frame
    void Update()
    {

        float vert = 0;
        float horiz = 0;
        vert = Input.GetAxis("Vertical 1");
        horiz = Input.GetAxis("Horizontal 1");

        body.velocity = new Vector2(horiz * stats.speed, -vert * stats.speed);
        HPprog.maximum = stats.MaxHP;
        HPprog.current = stats.HP;
        HPText.text = stats.HP + "/" + stats.MaxHP;


    }

    bool isRunning = false;

    void OnCollisionEnter2D(Collision2D colission)
    {
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
