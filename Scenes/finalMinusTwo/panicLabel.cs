using Godot;
using System;

public partial class panicLabel : Label
{

	Timer timer;
	Timer timer2;
	Camera2D camera;
	public int insults = 0;

	string[] panics = new string[]
	{
		"I'm not good enough",
		"I'll never be able to do this",
		"I'm a failure",
		"No one cares about me",
		"I'm not smart enough for this",
		"I always mess everything up",
		"I'm not talented enough",
		"Things will never get better",
		"I don't deserve happiness",
		"Why even bother trying?",
		"People are better off without me",
		"I'll never be successful",
		"Everything I do is wrong",
		"I’m just a burden to others",
		"I’ll never be as good as they are",
		"It's too late for me to change",
		"I'm not worth the effort",
		"No matter how hard I try, I’ll fail",
		"I'm not important",
		"I'll never be happy"
	};

	Random rnd = new Random();
	

	public override void _Ready()
	{
		camera = GetNode<Camera2D>("Camera2D");
		timer = GetNode<Timer>("Timer");
		timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.

    public override void _Process(double delta)
    {
    }
	public void OnTimerTimeout()
	{
		Text = panics[rnd.Next(0, panics.Length)];
		insults ++;
		if (timer.WaitTime > 0.05){
			timer.WaitTime = 1 - insults * 0.04;
		}
		camera.Offset = new Vector2(rnd.Next(-insults, insults) * 0.2f, rnd.Next(-insults, insults) * 0.2f);

		if (insults > 100){
			Text = "I'll try harder next time.";
			camera.Offset = new Vector2(0,0);
		}

		if (insults > 160){
			GetTree().ChangeSceneToFile("res://Scenes/finalMinusOne/finalMinusOne.tscn");
		}
	}
}

