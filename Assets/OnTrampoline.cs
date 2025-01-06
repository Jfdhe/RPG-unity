using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrampoline : MonoBehaviour
{
    public int trampolineStrenght;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<UnityPhysixTest>().jumpBoost(trampolineStrenght);
        }
    }
}
