﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private bool _holdingItem;
    private GameObject itemForPickUp;
    private FixedJoint _joint;
    public Button raiseButton;

    // Start is called before the first frame update
    void Start()
    {
        _holdingItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_holdingItem && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Drop");
            Destroy(_joint);
            _holdingItem = false;
            //StartCoroutine(turnOnisKinematic());
        } 
    }

    //IEnumerator turnOnisKinematic()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    itemForPickUp.GetComponent<Rigidbody>().isKinematic = true;
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide");
        if (other.tag.Equals("Movable") && _holdingItem == false)
        {
            
            other.gameObject.AddComponent<FixedJoint>();
            itemForPickUp = other.gameObject;
            _joint = other.gameObject.GetComponent<FixedJoint>();
            other.gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            _holdingItem = true;
        }
        else if (other.tag.Equals("Boom"))
        {
            Debug.Log("Pulley at top");
            raiseButton.interactable = false;
        }
    }

}
