using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MyTimer :IDisposable
{
    public float timer;
    private Action _actionComplete;
    private float _finishTime;
    private bool _isRunning;
    private IDisposable _observerDisposable;

    public MyTimer(float finishTime, Action actionComplete) {
        this._finishTime = finishTime;
        this._actionComplete = actionComplete;
        _observerDisposable = Observable.EveryGameObjectUpdate().
            Where(x => _isRunning).Subscribe(_ => Update());

    }
    public void Restart() {
        _isRunning = true;
        timer = 0.0f;
    }
    public void ShutDown() {
        _isRunning = false;
    }

    private void Update() {
        timer += Time.deltaTime;
        if(timer < _finishTime) return;

        timer = 0.0f;
        _isRunning = false;
        _actionComplete();
    }
    public void Dispose() {
        _observerDisposable.Dispose();
        _observerDisposable = null;
        _actionComplete = null;
    }
}

