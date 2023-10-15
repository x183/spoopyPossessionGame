using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Signal]
	public delegate void ReleasePossessionEventHandler();
	[Export]
	public int speed = 15000;

	private AudioStreamPlayer2D playerSound;
	private bool wasOnSomething = false;
	private bool hasPossessed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Check for possession
		if (hasPossessed && !Input.IsActionJustReleased("possess")) {
			return;
		}
		if (Input.IsActionJustReleased("possess")) {
			switch (hasPossessed) {
				case true:
					// ReleasePossession()
					hasPossessed = false;
					EmitSignal(SignalName.ReleasePossession);
					break;
				case false:
					// PossessMonster()
						break;
			}

		}

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
		if (hasPossessed) { // Do not update physics if player has possessed
			return;
		}
		Velocity = getMovement() * (float)delta * speed;
		MoveAndSlide();
		if ((IsOnWall() || IsOnCeiling() || IsOnFloor()))
		{
			if (wasOnSomething == false && !playerSound.Playing)
			{
				wasOnSomething = true;
				playerSound.Play();
			}
		}
		else wasOnSomething = false;
	}

	private void OnBodyEntered(PhysicsBody2D body)
	{
		Hide(); // Player disappears after being hit.

		// Must be deferred as we can't change physics properties on a physics callback.
		GetNode<CollisionShape2D>("PlayerCollision").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
	}

	public void Start(Vector2 position)
	{
		playerSound = GetNode<AudioStreamPlayer2D>("PlayerSound");
		Position = position;
		Show();
		//	GetNode<CollisionShape2D>("PlayerCollision").Disabled = false;
	}

	private Vector2 getMovement() {
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
	private void _on_release_possession()
	{
		// Replace with function body.
		QueueFree();
	}
}
