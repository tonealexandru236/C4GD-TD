using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Canvas;
    private GameObject ist = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        ist = Instantiate(gameObject, Canvas.transform);
        Destroy(ist.GetComponent<Drag>());
        ist.GetComponent<Image>().color = new Color(ist.GetComponent<Image>().color.r, ist.GetComponent<Image>().color.g, ist.GetComponent<Image>().color.b, 0.3f);
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
        Destroy(ist);
        ist = null;
    }
}
