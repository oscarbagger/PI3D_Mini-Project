using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float timeToDestroy=10;
    void Start()
    {
        Destroy(this.gameObject,timeToDestroy);   
    }
}
