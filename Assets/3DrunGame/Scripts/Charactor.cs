using UnityEngine;
using UnityEngine.InputSystem;

public class Charactor : MonoBehaviour
{
    [SerializeField] float sp;

    Vector2 moveVec;


    private void OnMove(InputValue value)
    {
        moveVec = value.Get<Vector2>();
    }


    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(moveVec.x*sp, 0.0f, sp);
    }
}
