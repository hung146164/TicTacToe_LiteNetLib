using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonEffectChange : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler,IPointerClickHandler
{
    Image _buttonImage;
    public ButtonEffectConfig buttonEffectConfig;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }
    private void Start()
    {
        Normal();
    }
    public void Enter()
    {
        //Debug.Log("Ishover");
        _buttonImage.color = buttonEffectConfig.Enter;
    }
    public void Normal()
    {
        _buttonImage.color = buttonEffectConfig.Normal;
    }
    public void Press()
    {
        _buttonImage.color = buttonEffectConfig.Press;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Normal");
        Normal();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Hover");
        //Enter();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Click");
        Press();
    }
}
