using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Geometry Settings", fileName = "Figures")]
public class GeometryObjectData : ScriptableObject
{
    [SerializeField, HideInInspector] private List<ClickColorData> _clicksDataList;

    [SerializeField] private ClickColorData _currentClicksData;
    private int _currentIndex = 0;
  
    public void AddElement() {
        if(_clicksDataList == null)
            _clicksDataList = new List<ClickColorData>();

        _currentClicksData = new ClickColorData();
        _clicksDataList.Add(_currentClicksData);

        _currentIndex = _clicksDataList.Count - 1;
    }
  
    public void RemoveCurrentElement() {
        if(_currentIndex > 0)
        {
            _currentClicksData = _clicksDataList[--_currentIndex];
            _clicksDataList.RemoveAt(++_currentIndex);
        }
        else
        {
            _clicksDataList.Clear();
            _currentClicksData = null;
        }
    }

    public ClickColorData GetElement(int index) {        
        _currentClicksData = this[index];
        return _currentClicksData;
    }

    public ClickColorData GetNext() {
        if(_currentIndex < _clicksDataList.Count - 1)
            _currentIndex++;
        _currentClicksData = this[_currentIndex];
        return _currentClicksData;
    }

    public ClickColorData GetPrevious() {
        if(_currentIndex > 0)
            _currentIndex--;
        _currentClicksData = this[_currentIndex];
        return _currentClicksData;
    }

    public void ClearClickData() {
        _clicksDataList.Clear();
        _clicksDataList.Add(new ClickColorData());
        _currentClicksData = _clicksDataList[0];
        _currentIndex = 0;   
    }

    public ClickColorData GetRandomElement() {
        int random = Random.Range(0, _clicksDataList.Count);
        return _clicksDataList[random];
    }

    public ClickColorData this[int index]
    {
        get
        {
            if(_clicksDataList != null && index >= 0 && index < _clicksDataList.Count)
                return _clicksDataList[index];
            return null;
        }

        set
        {
            if(_clicksDataList == null)
                _clicksDataList = new List<ClickColorData>();

            if(index >= 0 && index < _clicksDataList.Count && value != null)
                _clicksDataList[index] = value;
            else Debug.Log("Выход за границы массива, либо значения = null!");
        }

    }
}

[System.Serializable]
public class ClickColorData
{
    [SerializeField] public Figure ObjectType;

    [SerializeField] public int MinClicksCoun;
    [SerializeField] public int MaxClicksCoun;

    [SerializeField] public Color Color;
    [SerializeField] public int DeleyBeforeColorChange;
}

