using System;
using UnityEngine;

public class UnityPhysixTest : MonoBehaviour
{
    public GameObject interactPanel,interactPanelScam,spike;
    private bool onLever,haveItem;
    private GameObject pickUpItem;
    private PlayerHp playerHp;
    void Start()
    {
        interactPanelScam.SetActive(false);
        interactPanel.SetActive(false);
        playerHp = GetComponent<PlayerHp>();
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerHp.Damage(7);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        

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
    
    
}
