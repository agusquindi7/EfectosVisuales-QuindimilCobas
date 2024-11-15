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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_screens.Count <= 0)
                ActiveScreen(screenPaused);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            DesactiveScreen();
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
