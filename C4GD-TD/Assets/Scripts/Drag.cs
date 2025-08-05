using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Canvas;
    public GameObject Tower;
    private GameObject ist = null;
    public int price;

    public TMP_Text pricetag;

    public bool did_drag;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (MainButtons.instance.balance >= price)
        {
            did_drag = true;

            ist = Instantiate(gameObject, Canvas.transform);
            Destroy(ist.GetComponent<Drag>());
            ist.GetComponent<Image>().color = new Color(ist.GetComponent<Image>().color.r, ist.GetComponent<Image>().color.g, ist.GetComponent<Image>().color.b, 0.3f);
        }
        else
            MainButtons.instance.not_enough_money();
    }

    public void Update()
    {
        if(ist != null)
        {
            ist.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (did_drag == true)
        {
            Destroy(ist);
            did_drag = false;
            ist = null;

            GameObject twr = Instantiate(Tower);
            twr.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            twr.transform.position = new Vector3(twr.transform.position.x, twr.transform.position.y, 10);

            twr.GetComponent<Tower>().price = price;
        }
    }

    void Start()
    {
        pricetag.SetText(price + " $");
        did_drag = false;
    }

}
