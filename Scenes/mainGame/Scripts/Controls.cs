using Godot;
using System;

public partial class Controls : Sprite2D
{
    Node2D mainGame;

	public override void _Ready()
	{
		var mainGame = GetNode<MainGame>("/root/MainGame");
        if (mainGame.ingameDay == 1){
			Frame = 3;
        }
        if (mainGame.ingameDay == 2){
			Frame = 0;
        }
        if (mainGame.ingameDay == 3){
			Frame = 1;
        }
        if (mainGame.ingameDay == 4){
			Frame = 2;
        }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
