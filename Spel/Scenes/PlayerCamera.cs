using Godot;
using System;

public partial class PlayerCamera : Camera2D
{
	[Export]
	public TileMap tilemap;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var mapRect = tilemap.GetUsedRect();
		var tileSize = tilemap.CellQuadrantSize;
		var worldSize = mapRect.Size * tileSize;
		LimitRight = worldSize.X;
		LimitRight = worldSize.Y;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
