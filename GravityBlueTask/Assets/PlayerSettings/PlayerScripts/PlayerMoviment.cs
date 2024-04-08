using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    public float _playerSpeed;
    public Vector2 _playerPosition;
    public float _playerRotation;
    private Animator _playerAnim;


    private void Start()
    {
        ActivatePlayerControl();
    }

    public void ActivatePlayerControl()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }


    void Update()
    {
        _playerPosition = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_playerPosition.sqrMagnitude > 0)
        {
            _playerAnim.SetInteger("Moviment", 1);

        }
        else
        {
            _playerAnim.SetInteger("Moviment", 0);
        }
        Flip();
    }

    void Flip()
    {
        if (_playerPosition.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (_playerPosition.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);

        }
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + _playerPosition * _playerSpeed * Time.fixedDeltaTime);

    }

}
