using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeedPerSecond = 10.0f;
    void Update()
    {   //for moving ur bitch up
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //for moving ur bitch left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //for moving ur side bitch down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //for moving ur ´side bitch right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
    }
}
