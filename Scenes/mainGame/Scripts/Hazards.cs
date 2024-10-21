using Godot;
using System;

public partial class Hazards : Sprite2D
{
	Node2D mainGame;
	public override void _Ready()
	{
		var mainGame = GetNode<MainGame>("/root/MainGame");
		if (mainGame.ingameDay == 1){
			Frame = 0;
        }
        if (mainGame.ingameDay == 2){
			Frame = 1;
			Position += new Vector2(0, 10); 
        }
        if (mainGame.ingameDay == 3){
			Visible = false;
        }
        if (mainGame.ingameDay == 4){
        }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
