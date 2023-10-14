using Godot;
using System;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		NewGame();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void NewGame()
	{
		var player = GetNode<Player>("Player");
		var startPosition = GetNode<Marker2D>("StartPosition");
		player.Start(startPosition.Position);

		var buster = GetNode<GhostBuster>("GhostBuster");
		var busterPosition = GetNode<Marker2D>("BusterStartPosition");
		buster.Start(busterPosition.Position);
	}
}
