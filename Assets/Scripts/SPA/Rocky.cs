using UnityEngine;
using UnityEngine.InputSystem;

public class Rocky : MonoBehaviour
{
    private Bobserker bob;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.TryGetComponent(out  bob);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            bob.GetHit();
        }
    }
}
