using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// ����� ��� ���������� �������
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        /// <summary>
        /// ������ �� ������
        /// </summary>
        private Player player;

        private void Start()
        {
            player = GetComponent<Player>();
        }

        private void Update()
        {
            if (player == null) return;

            ControlKeyboard();
        }

        /// <summary>
        /// ���������� ���������� � ����������
        /// </summary>
        private void ControlKeyboard()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Vector2 movementVector = new Vector2(horizontalMovement, verticalMovement);

            if (movementVector.magnitude > 1)
            {
                movementVector = movementVector.normalized;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                //player.Fire(TurretMode.Primary);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                //player.Fire(TurretMode.Secondary);
            }

            player.MovementControl = movementVector;
        }
    }
}

