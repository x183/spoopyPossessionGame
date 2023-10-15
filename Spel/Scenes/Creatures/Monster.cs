using Godot;
using System;

public partial class Monster : CharacterBody2D
{
	[Export]
	public int Speed = 10000;

	private IMovementController _CurrentController;
	private IMovementController _PlayerController;
	private IMovementController _MonsterController;

	public override void _Ready() {
		_PlayerController = new PlayerController();
		_MonsterController = new IdleController();
		_CurrentController = _MonsterController;
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = _CurrentController.GetMovement() * Speed * (float)delta;
		MoveAndSlide();
	}

	public void Possess() {
		_CurrentController = _PlayerController;
	}

	private void _on_player_release_possession()
	{
		_CurrentController = _MonsterController;
	}
}
