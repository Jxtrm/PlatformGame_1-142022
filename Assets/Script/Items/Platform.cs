using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformEffector2D platformEffector;
    public float startWaitTime = 0f;

    private float waitedTime;

    // Start is called before the first frame update
    void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
        {
            waitedTime = startWaitTime;
        }

        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            if (waitedTime<=0)
            {
                platformEffector.rotationalOffset = 180f;
                waitedTime = startWaitTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space") || (Input.GetKey("up")))
        {
            platformEffector.rotationalOffset = 0;
        }
    }
}
