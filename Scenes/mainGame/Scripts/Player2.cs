using Godot;
using System;
using System.Drawing;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class Player2 : CharacterBody2D{

    float jumpVelocity = -400.0f;
    float speed = 10.0f;
    int direction = 0;
    private const float InteractableDistance = 30.0f;
    bool hazardDone = false;
    int darkMod;

    AnimationPlayer animPlayer;
    Sprite2D player;
    Sprite2D npc;
    Camera2D camera;

    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        player = GetNode<Sprite2D>("Player");		
        npc = GetNode<Sprite2D>("../Npc");
        camera = GetNode<Camera2D>("../Camera");
    }

    public override void _PhysicsProcess(double delta)
    {
        float direction = Input.GetAxis("left", "right");
        Velocity *= new Vector2((float)0.8, 1);

        if (direction != 0)
        {
            Velocity += new Vector2(speed * direction, 0);
            animPlayer.SpeedScale = 0.3f;
            animPlayer.Play("walk");    

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
    }
}