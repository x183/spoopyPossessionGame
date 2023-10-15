using Godot;
using System;

public partial class IdleMoveScript : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;
	private Random random = new Random();

	private Vector2 currentVelocity = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Func<float> randDir = () => ((float)random.NextDouble() * 2 - 1) * Speed;

		MoveAndSlide();
		if (IsOnWall() || Velocity == Vector2.Zero)
		{
			velocity.X = randDir();
			velocity.Y = randDir();
			Velocity = velocity;
		}
	}
}
