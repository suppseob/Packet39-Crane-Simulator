﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomUpDown : MonoBehaviour
{
    private HingeJoint BoomHingeJoint;
    private JointMotor motor;
    public int MaxVeolcity;

    // Start is called before the first frame update
    void Start()
    {
        BoomHingeJoint = transform.GetComponent<HingeJoint>();


        motor = BoomHingeJoint.motor;
        motor.targetVelocity = 0;
        motor.force = 10;
        //Debug.Log(transform.name);
        BoomHingeJoint.motor = motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            MoveUp();
        } 
        else if (Input.GetKey("down"))
        {
            MoveDown();
        }
        else
        {
            motor.targetVelocity = 0;
            BoomHingeJoint.motor = motor;
        }
    }

    public void MoveUp()
    {
        if (motor.targetVelocity < MaxVeolcity)
            motor.targetVelocity += 1;
        Debug.Log("Up arrow pressed.\n" + motor.targetVelocity.ToString());
        BoomHingeJoint.motor = motor;
    }

    public void MoveDown()
    {
        if (motor.targetVelocity > (MaxVeolcity * -1))
            motor.targetVelocity -= 1;
        Debug.Log("Down arrow pressed.\n" + motor.targetVelocity.ToString());
        BoomHingeJoint.motor = motor;
    }
}
