using Godot;
using System;

public partial class GhostBuster : CharacterBody2D
{
	[Export]
	public CharacterBody2D player;
	public const float Speed = 100.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 position = Position;
		Vector2 playerPosition = player.Position;
		Vector2 direction = (playerPosition - position);

		Vector2 normDir = direction.Normalized();

		velocity = normDir * Speed;
		Velocity = velocity;
		MoveAndSlide();
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);
			if ((collision.GetCollider() as Node).Name == "Player") GetTree().Quit();
		}
	}

	public void Start(Vector2 position)
	{
		Position = position;
		Show();
	}

	private void OnBodyEntered(PhysicsBody2D body)
	{
		GD.Print("Body entered");
		if (body == player)
			GetTree().Quit();
	}
}
