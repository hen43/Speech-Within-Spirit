using Godot;
using System;

public partial class DayScreen : Node2D
{

    Timer timer;
	Label label;
	Sprite2D sprout;
	Node2D mainGame;


	public override void _Ready()
	{
		timer = GetNode<Timer>("DayTimer");
		label = GetNode<Label>("Control/Label");
		sprout = GetNode<Sprite2D>("Sprout");

        timer.Start();
        timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
		Visible = true;

		updateSprout();
	}

	public void OnTimerTimeout()
    {
		var mainGame = GetNode<MainGame>("/root/MainGame");
        Visible = false;

		if (mainGame.ingameDay == 5){
			GetTree().ChangeSceneToFile("res://Scenes/finalMinusTwo/finalMinusTwo.tscn");
		}
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Key9)){
			GetTree().ChangeSceneToFile("res://Scenes/finalMinusTwo/finalMinusTwo.tscn");	
		}	
	}

	public void updateSprout(){
		var mainGame = GetNode<MainGame>("/root/MainGame");

		sprout.Frame = mainGame.ingameDay - 1; 
	}
}
