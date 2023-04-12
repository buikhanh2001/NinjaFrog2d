using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float startWaitime;
    private float waitedtime;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            waitedtime = startWaitime;
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if (waitedtime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitedtime = startWaitime;
            }
            else
            {
                waitedtime -= Time.deltaTime;
            }
        }
        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
