using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		
		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
		
#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}
		

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnCursor(InputValue value)
		{
			if (value.isPressed) // 仅在按下时切换光标状态
			{
				cursorLocked = !cursorLocked; // 切换光标锁定状态
				SetCursorState(cursorLocked);
				Debug.Log("Cursor Locked: " + cursorLocked);
			}
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
		
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		public void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}
		
		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked: CursorLockMode.None;
		}
	}
}