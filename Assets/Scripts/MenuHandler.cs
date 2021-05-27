using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuHandler : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvents = new UnityEvent();
    public UnityEvent OnTriggerExitEvents = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit hit;
        if(Physics.Raycast(player.transform.position, player.transform.forward, out hit, threshold))
        {
            Debug.Log("hit");
            //Vector3 objectHit = hit.point;
            //hit.collider.gameObject
            if(hit.collider.gameObject.tag == target.tag)
            {
                menu.SetActive(true);
                Debug.Log("hit2");
            }

        }
        else
        {
            menu.SetActive(false);
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnTriggerEnterEvents.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OnTriggerExitEvents.Invoke();
        }
    }
}
