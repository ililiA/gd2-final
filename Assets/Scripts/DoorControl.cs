using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Animator _Anim;
    // Start is called before the first frame update
    void Start()
    {
        _Anim = this.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _Anim.SetTrigger("doorTrigger");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _Anim.SetTrigger("doorTrigger");
        }
    }
}
