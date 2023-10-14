using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Signal]
	public delegate void HitEventHandler();

	public Vector2 ScreenSize; // Size of the game window.

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("PlayerAnimation");
		if (Velocity.Length() > 0)
		{
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		if (Velocity.X != 0)
		{
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.FlipV = false;
			// See the note below about boolean assignment.
			animatedSprite2D.FlipH = Velocity.X < 0;
		} else if (Velocity.Y != 0)
		{
			animatedSprite2D.Animation = "up";
			animatedSprite2D.FlipV = Velocity.Y > 0;
		}
	}

	public override void _PhysicsProcess(double delta) {
		MoveAndSlide();
	}

	private void OnBodyEntered(PhysicsBody2D body)
	{
		Hide(); // Player disappears after being hit.
		EmitSignal(SignalName.Hit);
		// Must be deferred as we can't change physics properties on a physics callback.
		GetNode<CollisionShape2D>("PlayerCollision").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
	}

	public void Start(Vector2 position)
	{
			Position = position;
			Show();
		//	GetNode<CollisionShape2D>("PlayerCollision").Disabled = false;
	}
}
