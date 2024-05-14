using System;
using UnityEngine;


public class GameSystem : MonoBehaviour
{
    private InputController _inputController;
    
    private void Start()
    {
        _inputController = new InputController();
    }

    private void Update()
    {
        _inputController.Update();
    }
}