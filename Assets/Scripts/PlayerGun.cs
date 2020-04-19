using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    Camera cam;
    Transform my;

    public Object BULL = new Object();
    public int bullets_per_shot = 1;
    public int max_bull = 5;
    public int current_bull = 0;
    public float timeBetweenBullets = 0;
    public int spread = 90;
    Stats stats;
    int bulletCountdown;
    public GameObject bulletbar;
    ProgressBar bulletprog;
    Text bulletText;


    void Start()
    {
        stats = GetComponent<Stats>();
        current_bull = max_bull;
        bulletprog = bulletbar.GetComponent(typeof(ProgressBar)) as ProgressBar;
        bulletText = bulletbar.GetComponentInChildren(typeof(Text)) as Text;
        bulletCountdown = max_bull;
        InvokeRepeating("BulletCountd", 0, timeBetweenBullets);
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg());


        if (Input.GetButtonDown("Fire1") & current_bull > 0 & !is_shootin)
        {


            if (bullets_per_shot < current_bull)
            {
                StartCoroutine(ShootMultiBullet(bullets_per_shot)); current_bull = current_bull - bullets_per_shot;
            }
            else { StartCoroutine(ShootMultiBullet(current_bull)); current_bull = 0; }

        }

        if (Input.GetButtonDown("Fire2"))
        {
            current_bull = max_bull;
        }
        bulletprog.maximum = max_bull;
        bulletprog.current = bulletCountdown;
        bulletText.text = bulletCountdown + "/" + max_bull;


    }



    bool is_shootin = false;

    void ShootBullet()
    {
        Vector3 Right = Vector3.zero;
        Right.x = 4f;
        GameObject bullet = (GameObject)Instantiate(BULL, transform.localPosition + transform.TransformPoint(Right), transform.rotation);
        Stats bullets = bullet.GetComponent<Stats>();
        bullets.speed = stats.speed;

        bullets.strength = stats.strength;
    }

    IEnumerator ShootMultiBullet(int bullet)
    {
        is_shootin = true;

        for (int i = 0; i < bullet; i++)
        {
            ShootBullet();
            yield return new WaitForSeconds(timeBetweenBullets);
        }

        is_shootin = false;

    }

    void BulletCountd()
    {
        {
            if (bulletCountdown > current_bull)
            {
                bulletCountdown = bulletCountdown - 1;
            }
            if (bulletCountdown < current_bull)
            {
                bulletCountdown = bulletCountdown + 3;
            }


        }
    }
    float AngleDeg()
    {
        float AngleDeg = 0;
        Vector3 lookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);


        switch (InputControl.GetInputState())
        {
            case InputControl.eInputState.MouseKeyboard:
                AngleDeg = (180 / Mathf.PI) * AngleRad;

                break;
            case InputControl.eInputState.Controler:
                AngleDeg = Mathf.Atan2(Input.GetAxis("Vertical 2"), Input.GetAxis("Horizontal 2"));
                break;
        }
        return AngleDeg;
    }
}
