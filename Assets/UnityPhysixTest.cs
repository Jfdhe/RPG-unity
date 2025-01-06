using System;
using UnityEngine;

public class UnityPhysixTest : MonoBehaviour
{
    public GameObject interactPanel,interactPanelScam,spike;
    private bool onLever,haveItem;
    private GameObject pickUpItem;
    void Start()
    {
        interactPanelScam.SetActive(false);
        interactPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (haveItem)
            {
                pickUpItem.SetActive((false));
            }
            if (onLever)
            {
                interactPanelScam.SetActive(true);
                spike.SetActive(true);
                interactPanel.SetActive(false);
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (hit.gameObject.CompareTag("Item"))
        {
            interactPanel.SetActive(true);
            haveItem = true;
            pickUpItem = hit.gameObject;
        }
        else
        {
            haveItem = false;
        }

        if (hit.gameObject.CompareTag("Lever"))
        {
            interactPanel.SetActive(true);
            onLever = true;
        }
        else
        {
             onLever = false;
        }
        
        if (!hit.gameObject.CompareTag("Lever") && !hit.gameObject.CompareTag("Item"))
        {
             interactPanel.SetActive(false);
        }

        if (hit.gameObject.CompareTag("Button")) 
        {
            hit.gameObject.GetComponent<ButtonPressed>().OnButtonPressed();
        }
    }
    public void jumpBoost(int trampolineBounceStrenght)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * trampolineBounceStrenght);
    }
}
