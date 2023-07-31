using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class movebytouch : MonoBehaviour
{
    public RectTransform background;
    public RectTransform handle;
    [Range(0, 2f)] public float handlelimit = 1f;
    Vector2 input = Vector2.zero;

    public void onPointerDown(PointerEventData eventData)
    {
        onDrag(eventData);
    }
    public void onPointerUp(PointerEventData eventData)
    {

    }
    public void onDrag(PointerEventData eventData)
    {

    }
}
