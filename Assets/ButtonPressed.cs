using System;
using System.Collections;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    [SerializeField] private Animator myButton = null;

    [SerializeField] private bool openTrigger = true;
    private bool playerPressing;

    private void Start()
    {
        StartCoroutine(DelayOff());
    }

    public void OnButtonPressed()
    {

        playerPressing = true;
        if (openTrigger) {
                myButton.Play("PressButton");
                StartCoroutine(DelayOff());
                openTrigger = false;
        }
    }

    private IEnumerator DelayOff()
    {
        while (true)
        {
            if (playerPressing == false && openTrigger == false)
            {
                myButton.Play("UnpressedButton");
                openTrigger = true;

            }
            playerPressing = false;
            yield return new WaitForSeconds(1.5f);
        }
    }
}