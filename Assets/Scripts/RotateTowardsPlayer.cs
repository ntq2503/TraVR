using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled)
        {
            Vector3 offset = transform.position - player.transform.position;

            Vector3 rotation = Vector3.RotateTowards(transform.forward, offset, Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(rotation);
        }
    }
}
