using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed=100f;

    public GameObject gun;
    public Joystick joystick;
    public Transform lookObject;

    private Rigidbody2D _rb;
    private Camera _cam;

    private Vector2 _movement;
    private Vector2 _mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = joystick.Horizontal;
        _movement.y = joystick.Vertical;

        _mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        TankBodyMovement();
        GunMovement();
    }

    void TankBodyMovement()
    {
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        float zAxis = -Mathf.Atan2(_movement.x, _movement.y) * Mathf.Rad2Deg;
        if (zAxis != 0)
            transform.eulerAngles = new Vector3(0, 0, zAxis);
    }

    void GunMovement()
    {
        Vector2 lookDir = new Vector2(lookObject.position.x, lookObject.position.y) - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
