using System.Collections;
using UnityEngine;
using UniRx;
using System;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private Figure _figure;

    private void Start() {
        StartCoroutine(RandomColorDelay(_figure.settings.DeleyBeforeColorChange));
    }
    private IEnumerator RandomColorDelay(int delay) {
        while(true)
        {
            if(_figure.randomColor)
            {
                _figure.ColorFigure = Color();
                yield return new WaitForSeconds(delay);              
            }
            else
            {
                yield return new WaitForSeconds(0);
            }
        }
    }

    private Color Color() {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }
}
