using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{

    public GameObject ball;
    public GameObject myHand;

    bool inHands = false;
    Vector3 ballPosition;

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.C))
        {
            if (!inHands)
            {
                ball.transform.SetParent(myHand.transform);
                ball.transform.localPosition = new Vector3(0f, -.672f,0f);
                inHands = true;
            } else if (inHands)
            {
                this.GetComponent<PlayerGrab>().enabled = false;
                ball.transform.SetParent(null);
                ball.transform.localPosition = ballPosition;
                inHands = false;
            }
        }
    }
}
