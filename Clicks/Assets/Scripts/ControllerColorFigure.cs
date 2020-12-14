using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerColorFigure : MonoBehaviour
{
    public void ColorInRange(Figure figure, ClickColorData settings) {
        if(figure.CounterOfClicks >= settings.MinClicksCoun && figure.CounterOfClicks <= settings.MaxClicksCoun)
        {
            figure.randomColor = false;
            figure.SetColor(figure, settings);
        }
        else if(figure.CounterOfClicks < settings.MinClicksCoun || figure.CounterOfClicks > settings.MaxClicksCoun)
        {
            figure.randomColor = true;
        }
    }
}
