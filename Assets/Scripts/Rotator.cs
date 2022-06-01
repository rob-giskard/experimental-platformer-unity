using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator: MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Vector3 rotateVector;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateVector * Time.deltaTime);        
    }
}
