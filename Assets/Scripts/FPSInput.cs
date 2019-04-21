using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.8f;

    private float deltaX = 0f;
    private float deltaZ = 0f;
    private CharacterController _charController;


    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    { 
        deltaX = Input.GetAxis("Horizontal") * speed;
        deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);     //ограничвает модуль вектора числом speed
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);      //переход к глоб сист коорд
        _charController.Move(movement);
    }
}
