using UnityEngine;

namespace Game0
{
    public class OldUserInputController : BaseUserInputController
    {
        protected override void OnMoving()
        {
            if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow))
            {
                movingVector = transform.forward;
            }
            else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
            {
                movingVector = -transform.forward;
            }
            else if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
            {
                movingVector = -transform.right;
            }
            else if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
            {
                movingVector = transform.right;
            }
            else
            {
                movingVector = Vector3.zero;
            }
        }

        protected override void OnRotation()
        {
            rotateDirection = Input.GetKey(KeyCode.Q) ? -1 : Input.GetKey(KeyCode.E) ? 1 : 0;
        }

        protected override void OnJumping()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isJumping = true;
            }
        }
    }
}