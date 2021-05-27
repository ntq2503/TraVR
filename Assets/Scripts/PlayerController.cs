using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int cashAmount;
    public TMP_Text cashText;
    public List<Sprite> inventory;
    public GameObject inventPanel;
    public Transform[] taskLocations;
    public AudioClip cashSound;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        updateCash();
        foreach (Sprite item in inventory)
        {
            addItem(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void addItem(Sprite item)
    {
        GameObject newImage = new GameObject();
        newImage.AddComponent<Image>();
        newImage.GetComponent<Image>().sprite = item;
        newImage.GetComponent<Image>().preserveAspect = true;
        newImage.transform.parent = inventPanel.transform;
        newImage.transform.localScale = new Vector3(1, 1, 1);
        newImage.transform.localPosition = new Vector3(newImage.transform.localPosition.x, newImage.transform.localPosition.y, 0);
        newImage.transform.localEulerAngles = Vector3.zero;
    }

    IEnumerator updateCash()
    {
        yield return new WaitForSeconds(1.5f);
        cashText.text = cashAmount.ToString();
    }

    public void obtainItem(Image item)
    {
        inventory.Add(item.sprite);
        addItem(item.sprite);
    }

    public void makePurchase(TMP_Text price)
    {
        cashAmount -= int.Parse(price.text);
        audio.PlayOneShot(cashSound);
        StartCoroutine(updateCash());
    }

    public void goToTask(int n)
    {
        //Debug.Log("go " + n);
        gameObject.transform.position = new Vector3(taskLocations[n].position.x, gameObject.transform.position.y, taskLocations[n].position.z);
    }
}
