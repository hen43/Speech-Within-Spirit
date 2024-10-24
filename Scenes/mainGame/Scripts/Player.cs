using Godot;
using System;
using System.Drawing;

public partial class Player : CharacterBody2D{

    float jumpVelocity = -400.0f;
    float speed = 50.0f;
    int direction = 0;
    private const float InteractableDistance = 30.0f;
    bool hazardDone = false;
    int darkMod;

    AnimationPlayer animPlayer;
    Sprite2D player;
    Sprite2D hazards;
    Sprite2D npc;
    Label label;
    Node2D mainGame;
    Camera2D camera;
    Label cameraLabel;
    Node2D dayScreen;
    Sprite2D controls;

    

    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        player = GetNode<Sprite2D>("Player");		
        hazards = GetNode<Sprite2D>("../Hazards");
        npc = GetNode<Sprite2D>("../Npc");
        label = GetNode<Label>("../Npc/Label");
        camera = GetNode<Camera2D>("../Camera");
        cameraLabel = GetNode<Label>("../Camera/DayScreen/Control/Label");
        dayScreen = GetNode<Node2D>("../Camera/DayScreen");
        controls = GetNode<Sprite2D>("../Controls");
    }

    public override void _PhysicsProcess(double delta)
    {
        float direction = Input.GetAxis("left", "right");
        Velocity *= new Vector2((float)0.8, 1);
        var mainGame = GetNode<MainGame>("/root/MainGame");

        if (Input.IsActionPressed("up") && IsOnFloor() && mainGame.ingameDay <= 2)
        {
            Velocity += new Vector2(0, jumpVelocity);
        }

        if (direction != 0)
        {
            Velocity += new Vector2(direction * speed, 0);
            
            if (Input.IsKeyPressed(Key.Space) && mainGame.ingameDay == 1)
            {
                animPlayer.Play("run");
                Velocity += new Vector2(direction * speed, 0);
            } else {
                animPlayer.Play("walk");
            }

            if (direction == 1){
                player.FlipH = false;
            } else if (direction == -1){
                player.FlipH = true;
            }
            
        } else {
            animPlayer.Play("idle");
        }

        if (IsOnFloor() == false)
        {
            Velocity += GetGravity() * (float)delta;
            animPlayer.Play("fall");
        }

        MoveAndSlide();
    }

    public override void _Process(double delta)
    {
        var mainGame = GetNode<MainGame>("/root/MainGame");

        bool interactable = Mathf.Abs(Position.X - hazards.Position.X) < InteractableDistance;

		if (interactable && (hazardDone == false)){
            if (mainGame.ingameDay <= 2){
                Velocity = new Vector2(5, 300);
                animPlayer.Play("trip");
            }
            label.Scale = new Vector2(0.6f,0.6f);
            label.Visible = true;

            if (mainGame.ingameDay == 1){
                label.Text = "Did you seriously\ntrip over that?.";
            }
            if (mainGame.ingameDay == 2){
                label.Text = "BWAHAHAHA!! You suck \nat jumping puddles.";
            }
            if (mainGame.ingameDay == 3){
                label.Text = "Get out of here.";
            }
            if (mainGame.ingameDay == 4){
                label.Text = "(Did you see how weird\nthat kid looked? Sheesh.)";
            }
		}

        if (Position.X > 1600){
            changeDay();
        }
    }

    

    public void changeDay(){
        var mainGame = GetNode<MainGame>("/root/MainGame");
        Position = new Vector2(0,380);
        mainGame.ingameDay += 1;
        if (mainGame.ingameDay == 2){
            cameraLabel.Text = "DAY TWO";
        }
        if (mainGame.ingameDay == 3){
            cameraLabel.Text = "DAY THREE";
        }
        if (mainGame.ingameDay == 4){
            cameraLabel.Text = "DAY FOUR";
        }
        if (mainGame.ingameDay == 5){
            cameraLabel.Text = "DAY FIVE";
        }

        speed = 50.0f * (1 - mainGame.ingameDay * 0.19f);
        animPlayer.SpeedScale = 1 - mainGame.ingameDay * 0.19f;
        dayScreen._Ready();
        npc._Ready();
        hazards._Ready();
        controls._Ready();
    }
}
