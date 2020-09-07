using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public GameObject leftPaddle;
    public GameObject rightPaddle;

    private float amplify = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftPaddle.transform.Translate(0, 0, Input.GetAxis("W + S") * Time.deltaTime * amplify);
        rightPaddle.transform.Translate(0, 0, Input.GetAxis("Up + Down") * Time.deltaTime * amplify);
    }
}
