using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    Camera cam;
    Transform my;

    public Object BULL = new Object();
    public int bullets_per_shot = 1;
    public int max_bull = 5;
    public int current_bull = 0;
    public float timeBetweenBullets = 0;
    float usedtime = 0;
    public int spread = 90;
    Stats stats;
    int bulletCountdown;
    public GameObject bulletbar;
    ProgressBar bulletprog;
    Text bulletText;


    float RightTrigger;

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

        usedtime = timeBetweenBullets * 1 / RightTrigger;

        if (RightTrigger > 0 & current_bull > 0 & !is_shootin)
        {
            StartCoroutine(ShootMultiBullet()); current_bull = current_bull - 1;
        }

        bulletprog.maximum = max_bull;
        bulletprog.current = bulletCountdown;
        bulletText.text = bulletCountdown + "/" + max_bull;


    }
    public void Reload()
    {
        current_bull = max_bull;
    }

    InputDevice currentDevice;
    Vector2 lookHelp;
    public void OnLook(InputAction.CallbackContext context)
    {
        lookHelp = context.ReadValue<Vector2>();
                Debug.Log(lookHelp);

        currentDevice = context.control.device;
    }

    public void onFire(InputAction.CallbackContext context)
    {
        RightTrigger = context.ReadValue<float>();
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

    IEnumerator ShootMultiBullet()
    {
        is_shootin = true;


        ShootBullet();
        yield return new WaitForSeconds(usedtime);


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
        float AngleDeg;
        float AngleRad;
        float vert = lookHelp.y;
        float horiz = lookHelp.x;
        if (currentDevice == Mouse.current)
        {
            Vector3 lookAt = Camera.main.ScreenToWorldPoint(lookHelp);
            AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        }
        else
        {

            AngleRad = Mathf.Atan2(vert, horiz);
        }
        AngleDeg = (180 / Mathf.PI) * AngleRad;
        return AngleDeg;
    }
}
