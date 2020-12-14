using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : Figure, IPointerClickHandler
{
    public override event Action<int> ClickObjectEvent;
    public override Color ColorFigure
    {
        get => renderer.material.color;
        set => renderer.material.color = value;
    }

    private void Awake() {
        renderer = GetComponent<Renderer>();
    }

    private void Start() {
        Settings();
        controllerColor = GetComponent<ControllerColorFigure>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        ThrowRay(this);
        if(rayHit)
        {
            ClickObjectEvent?.Invoke(CounterOfClicks);
            controllerColor.ColorInRange(this, settings);
        }
    }

    public override void Settings() {
        for(int i = 0; i < 3; i++)
        {
            settings = figureSettings.GetElement(i);
            if(settings.ObjectType is Cube)
                break;
        }
    }
}
