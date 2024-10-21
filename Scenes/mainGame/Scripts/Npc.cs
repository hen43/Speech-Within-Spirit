using Godot;
using System;

public partial class Npc : Sprite2D
{
    Timer timer;
    Label label;
    AnimationPlayer anim;
    CharacterBody2D player;
    MainGame mainGame;

    private const float InteractableDistance = 60.0f;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        label = GetNode<Label>("Label");
        anim = GetNode<AnimationPlayer>("AnimationPlayer");
        player = GetNode<CharacterBody2D>("../Player");

        timer.Start();
        timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
        label.Visible = true;
        
        // Assign to the class-level mainGame variable
        mainGame = GetNode<MainGame>("/root/MainGame");

        UpdateLabel();
    }

    public void UpdateLabel()
    {
        mainGame = GetNode<MainGame>("/root/MainGame");
        if (mainGame.ingameDay == 1)
        {
            label.Text = "Go away.";
        }
        else if (mainGame.ingameDay == 2)
        {
            label.Text = "Watch for that puddle.";
        }
        else if (mainGame.ingameDay == 3)
        {
            label.Text = "Why does your voice\n sound like that? Weirdo.";
        }
        else if (mainGame.ingameDay == 4)
        {
            label.Text = " ";
        }
    }

    public void OnTimerTimeout()
    {
        label.Visible = false;
    }

    public override void _Process(double delta)
    {
        playAnim();

        mainGame = GetNode<MainGame>("/root/MainGame");

        bool interactable = Mathf.Abs(Position.X - player.Position.X) < InteractableDistance && mainGame.ingameDay <= 3;

        if (interactable)
        {
            Modulate = new Color(1, 1, 0.6f, 1);

            if (Input.IsActionJustPressed("interact"))
            {
                label.Visible = true;
                timer.Start();
                GD.Print("test.");
            }
        }
        else
        {
            Modulate = new Color(1, 1, 1, 1);
        }
    }

    public void playAnim()
    {
        // Use the class-level mainGame variable
        if (mainGame.ingameDay == 1)
        {
            anim.Play("idle");
        }
        else if (mainGame.ingameDay == 2)
        {
            anim.Play("sway");
        }
        else if (mainGame.ingameDay == 3)
        {
            anim.Play("rock");
        }
        else if (mainGame.ingameDay == 4)
        {
            anim.Play("converse");
        }
    }
}
