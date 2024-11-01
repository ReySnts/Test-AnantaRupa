using UnityEngine;

namespace ProgrammerTest
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Transform playerView;

		private bool _facingRight = true;

		private const float Speed = 10f;

		private InputManager inputManager;

        private void Awake() => inputManager = GetComponentInParent<InputManager>();

        private	void Update()
		{
			if (inputManager.GetKeyA)
			{
				MoveHorizontal(Vector3.left);
				if (_facingRight)
				{
					_facingRight = false;
					UpdateFacing();
				}
			}
			else if (inputManager.GetKeyD)
			{
				MoveHorizontal(Vector3.right);
				if (!_facingRight)
				{
					_facingRight = true;
					UpdateFacing();
				}
			}
		}

		private void MoveHorizontal(Vector3 direction) => transform.position += Speed * Time.deltaTime * direction;

		private void UpdateFacing() => playerView.localScale = new Vector3(_facingRight ? 1 : -1, 1, 1);
	}
}