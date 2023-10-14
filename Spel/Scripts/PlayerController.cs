using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	public float speed { get; set; } = 100;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Velocity = Vector2.Zero;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		getInput();
	}

    public override void _PhysicsProcess(double delta)
    {
		float factor = speed * (float) delta;
		GetOwner<CharacterBody2D>().Velocity = new Vector2(factor * Velocity.X, factor * Velocity.Y);
    }

    private void getInput() {
		getMovement();
		getActions();
	}

	private void getActions() {
		// TODO if GetOwner() has some method 1/2 or 3 do that if input is correct
	}

	private void getMovement() {
		var velocity = Vector2.Zero;

		var right = Input.IsActionPressed("ui_right");
		var left = Input.IsActionPressed("ui_left");
		var up = Input.IsActionPressed("ui_up");
		var down = Input.IsActionPressed("ui_down");

		if (right) velocity.X += 1;
		if (left) velocity.X -= 1;
		if (up) velocity.Y -= 1;
		if (down) velocity.Y += 1;

		Velocity = velocity.Normalized();
	}
}