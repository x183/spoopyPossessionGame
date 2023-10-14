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
		var tileScale = tilemap.Scale;
		var worldSize = mapRect.Size * tileSize * (Vector2I)tileScale;
		LimitRight = worldSize.X;
		LimitBottom = worldSize.Y;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
