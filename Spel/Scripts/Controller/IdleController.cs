using Godot;
using System;

public partial class IdleController : IMovementController
{
	private Random random = new Random();

	public Vector2 GetMovement()
	{
		return new Vector2(((float)random.NextDouble() * 2 - 1), ((float)random.NextDouble() * 2 - 1)).Normalized();
	}
}
