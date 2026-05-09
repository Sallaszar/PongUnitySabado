using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Raquete : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limitY = 3.40f;

    private float myY;
    private void OnEnable()
    {
        moveAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
    }
    private void Start()
    {
        myY = transform.position.y;
    }
    private void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        myY += input.y *speed * Time.deltaTime;
        myY = Mathf.Clamp(myY, -limitY, limitY);

        Vector3 pos = transform.position;
        pos.y = myY;
        transform.position = pos;
    }

}
