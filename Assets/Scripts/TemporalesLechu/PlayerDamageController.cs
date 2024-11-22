using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    private PlayerLife _playerLife;

    private void Start()
    {
        _playerLife = GetComponent<PlayerLife>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _playerLife.TakeDamage(_playerLife.life); // Reduce la vida del jugador a 0
            Debug.Log("Vida del jugador reducida a 0.");
        }
    }
}
