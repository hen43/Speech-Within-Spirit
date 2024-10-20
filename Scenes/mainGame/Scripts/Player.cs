using Godot;
using System;

public partial class Player : CharacterBody2D{

    float jumpVelocity = -400.0f;
    float speed = 50.0f;
    int direction = 0;

    AnimationPlayer animPlayer;
    Sprite2D player;

    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        player = GetNode<Sprite2D>("Player");
    }

    public override void _PhysicsProcess(double delta)
    {
        float direction = Input.GetAxis("left", "right");
        Velocity *= new Vector2((float)0.8, 1);

        if (Input.IsActionPressed("up") && IsOnFloor() )
        {
            Velocity += new Vector2(0, jumpVelocity);
        }

        if (direction != 0)
        {
            Velocity += new Vector2(direction * speed, 0);
            
            if (Input.IsKeyPressed(Key.Space))
            {
                animPlayer.Play("run");
                Velocity += new Vector2(direction * speed * 2, 0);
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
        }

        MoveAndSlide();
    }

    public override void _Process(double delta)
    {
    }
}