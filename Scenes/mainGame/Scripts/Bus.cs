using Godot;
using System;

public partial class Bus : Sprite2D
{
    float speed = 0.0f;
    Timer timer;
    bool moveBus = false;

    public override void _Ready()
    {
        timer = GetNode<Timer>("busTimer");
        timer.Start();
        timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
    }

    public void OnTimerTimeout()
    {
        moveBus = true;
    }

    public override void _Process(double delta)
    {
        if (moveBus)  
        {
            speed -= 1f * (float)delta;
            Position += new Vector2(speed, 0);
        }
    }
}
