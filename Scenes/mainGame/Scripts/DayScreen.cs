using Godot;
using System;

public partial class DayScreen : Node2D
{
	// Called when the node enters the scene tree for the first time.

    Timer timer;
	public override void _Ready()
	{
		timer = GetNode<Timer>("DayTimer");
        timer.Start();
        timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
		Visible = true;
	}

	public void OnTimerTimeout()
    {
        Visible = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
