using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.InputSystem.InputAction;
using Game0.Interfaces;

namespace Game0
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterController : MonoBehaviour
    {
        #region Variables and properties

        private IInputable Input { get; set; }

        private NavMeshAgent agent;
        public GameObject targetDestination;
        public LayerMask whatCanBeClickedOn;
        [SerializeField, Range(10.0f,100.0f)] private float allowableClickDistance = 50f;
        private Vector2 mouseScreenPosion = Vector2.zero;
        private RaycastHit hitInfo;

        public event EventHandler<Vector3> PointOnMoveEvent;

        #endregion

        #region MonoBehaviour methods
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updatePosition = false;
        }

        #endregion

        #region Methods
        public void Bingding(IInputable input)
        {
            Input = input;
        }

        public void OnMouseScreenPosition(CallbackContext context)
        {
            if (context.performed)
            {
                mouseScreenPosion = context.ReadValue<Vector2>();
            }
        }

        public void OnMouseLeftButtonClick(CallbackContext context)
        {
            if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
            {
                Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosion);
                if (Physics.Raycast(ray, out hitInfo, allowableClickDistance, whatCanBeClickedOn))
                {
                    targetDestination.transform.position = hitInfo.point;

                    PointOnMoveEvent?.Invoke(this, hitInfo.point);

                    agent.SetDestination(hitInfo.point);
                }
            }
            //leftButtonMouseClick = context.performed ? true : false;
        }
        #endregion
    }
}