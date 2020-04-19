using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject toFollowO;
    Transform toFollow;
    Stats toFollowS;
    public float borderX;
    public float borderY;
    Vector3 stageDimensions;
    // Start is called before the first frame update
    float x_border_left;
    float x_border_right;

    float y_border_up;

    float y_border_down;
    Transform cam;

    void Start()
    {
        toFollow = toFollowO.GetComponent(typeof(Transform)) as Transform;
        toFollowS = toFollowO.GetComponent(typeof(Stats)) as Stats;

        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        x_border_left = -stageDimensions.x + borderX;
        x_border_right = stageDimensions.x - borderX;

        y_border_up = stageDimensions.y - borderY;

        y_border_down = -stageDimensions.y + borderY;

        cam = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tofollowP = toFollow.position;

        if (tofollowP.x > x_border_right || tofollowP.x < x_border_left || tofollowP.y < y_border_up || tofollowP.y > y_border_down)
        { cam.position = Vector3.MoveTowards(cam.position, toFollow.position + (Vector3.back * 10), toFollowS.speed/5); }
    }
}
