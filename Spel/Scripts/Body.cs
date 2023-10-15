using Godot;
using System;

public partial class Body : CharacterBody2D
{
	private bool isPossessed;
	public float _runSpeed { get; set; } = 350;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		this.isPossessed = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (this.isPossessed) {
			GetInput();
		}
	}

	public override void _PhysicsProcess(double delta) {
		if (this.isPossessed) {
			MoveAndSlide();
		}
	}

	private void GetInput() {
		var velocity = Vector2.Zero;

	}
}
