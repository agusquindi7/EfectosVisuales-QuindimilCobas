using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    public ScreenTest screenPaused;
    Stack<IScreen> _screens = new Stack<IScreen>();

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_screens.Count <= 0)
                ActiveScreen(screenPaused);
            Cursor.lockState = CursorLockMode.None;

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = CursorLockMode.Locked;
            DesactiveScreen();
        }
    }
    public void ActiveScreen(IScreen screen)
    {
        screen.Activate();

        if(_screens.Count > 0)
            _screens.Peek().Hide();


            //_screens.Peek().Desactivate();

        _screens.Push(screen);
    }

    public void DesactiveScreen()
    {
        if(_screens.Count > 0)
        {
            _screens.Pop().Desactivate();

            if(_screens.Count > 0 )
                _screens.Peek().Activate();
        }
    }
    
}
