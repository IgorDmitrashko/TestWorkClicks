using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Figure : MonoBehaviour
{
    [SerializeField] protected GeometryObjectData figureSettings;

    protected string Name { get; set; }  
    protected new Renderer renderer;
    protected bool rayHit = false;

    protected ControllerColorFigure controllerColor;
    public ClickColorData settings;

    public int CounterOfClicks { get; set; }
    public bool randomColor = true;

    public abstract Color ColorFigure { get; set; }
    public virtual void Settings() {
        
    }

    public abstract event Action<int> ClickObjectEvent;

    public void SetColor(Figure figure, ClickColorData colorData) {
        figure.ColorFigure = colorData.Color;
    }

    protected void ThrowRay(Figure figure) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray))
            figure.rayHit = true;
        figure.CounterOfClicks++;
    }

}
