using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private Vector2 direction = Vector2.zero;

    public UnityEvent OnStartInput;
    public UnityEvent OnEndInput;
    public UnityEvent<float,float> OnInput;

    private void Start()
    {
        joystick.OnStart.AddListener(OnStart);
        joystick.OnMove.AddListener(OnMove);
        joystick.OnStop.AddListener(OnStop);
    }

    private void OnStop()
    {
        direction = Vector2.zero;
        OnEndInput?.Invoke();
    }

    private void OnStart()
    {
        direction = joystick.Direction;
        OnStartInput?.Invoke();
    }

    private void OnMove()
    {
        direction = joystick.Direction;
        OnInput?.Invoke(direction.x, direction.y);
    }

    private void OnDestroy()
    {
        joystick.OnStart.RemoveListener(OnStart);
        joystick.OnMove.RemoveListener(OnMove);
        joystick.OnStop.RemoveListener(OnStop);
    }
}
