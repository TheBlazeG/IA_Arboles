using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    private Player actions;
    public float health = 100;
    public float speed = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.TryGetComponent(out controller);
        actions = new Player();
        actions.Keyboard.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = actions.Keyboard.Movement.ReadValue<Vector2>();
        controller.Move(new Vector3(input.x,0,input.y)*Time.deltaTime*speed);
    }

  
}
