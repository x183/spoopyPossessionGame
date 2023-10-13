using Godot;
using System;

public partial class Body : CharacterBody2D
{
	private bool isPossessed;
	private float _runSpeed = 350;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		this.isPossessed = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}

    public override void _PhysicsProcess(double delta) {
		GetInput();
		MoveAndSlide();
    }

	private void GetInput() {
		var velocity = new Vector2(0, 0);

		var right = Input.IsActionPressed("ui_right");
		var left = Input.IsActionPressed("ui_left");
		var up = Input.IsActionPressed("ui_up");
		var down = Input.IsActionPressed("ui_down");

		if (right) velocity.X += _runSpeed;
		if (left) velocity.X -= _runSpeed;
		if (up) velocity.Y -= _runSpeed;
		if (down) velocity.Y += _runSpeed;

		Velocity = velocity;
	}
}
