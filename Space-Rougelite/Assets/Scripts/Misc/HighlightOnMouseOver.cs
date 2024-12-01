using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color startcolor;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        startcolor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData) {image.color = Color.yellow; }
    public void OnPointerExit(PointerEventData eventData) { image.color = startcolor; }

    public void OnBecameVisable()
    {
       image.color = startcolor;
    }
}
