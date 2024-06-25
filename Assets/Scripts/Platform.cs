using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] static public float _moveSpeed;

    private GameObject _player;
    private int _moveDirection;
    private bool _hasToMove = true;
    //static public bool _PlatformCheck;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _moveDirection = transform.position.x < _player.transform.position.x ? 1 : -1;
    }
    void Start()
    {
        PlayerController._PlatformCheck = true;
    }

    
    void Update()
    {
        if (ScoreUI._score >= 0 && ScoreUI._score < 10)
                    _moveSpeed = 5;
                if (ScoreUI._score >= 10 && ScoreUI._score < 20)
                    _moveSpeed = 6;
                if (ScoreUI._score >= 20 && ScoreUI._score < 30)
                    _moveSpeed = 7;
                if (ScoreUI._score >= 30 && ScoreUI._score < 40)
                    _moveSpeed = 8;
                if (ScoreUI._score >= 40 && ScoreUI._score < 60)
                    _moveSpeed = 9;
                if (ScoreUI._score >= 60 && ScoreUI._score < 80)
                    _moveSpeed = 10;
                if (ScoreUI._score >= 80)
                    _moveSpeed = 11;
        if (PlayerController._PlatformCheck == true)
        {
            
            if (_hasToMove == true & PlayerController._PlatformCheck)
            {
                transform.position += Vector3.right * _moveDirection * _moveSpeed * Time.deltaTime;
            }
        }
        
           



    }

    public void StopMovement() => _hasToMove = false;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
