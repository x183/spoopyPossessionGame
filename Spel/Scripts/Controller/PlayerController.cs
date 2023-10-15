using Godot;
using System;

public partial class PlayerController : IMovementController
{
	public Vector2 GetMovement() {
		var velocity = Vector2.Zero;

		var right = Input.IsActionPressed("move_right");
		var left = Input.IsActionPressed("move_left");
		var up = Input.IsActionPressed("move_up");
		var down = Input.IsActionPressed("move_down");

		if (right) velocity.X += 1;
		if (left) velocity.X -= 1;
		if (up) velocity.Y -= 1;
		if (down) velocity.Y += 1;

		return velocity.Normalized();
	}
}
