
using UnityEngine;

public class OnTrampoline : MonoBehaviour
{
    public int trampolineStrenght;
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * trampolineStrenght);
        }
    }
}
