using Godot;
using System;
using System.Threading.Tasks;


public partial class Tender : Sprite2D
{
    AnimationPlayer anim;
    CharacterBody2D player;
    Label label;
    public int lines;
    public override void _Ready()
    {
        anim = GetNode<AnimationPlayer>("AnimationPlayer");
        player = GetNode<CharacterBody2D>("../Globber");
        label = GetNode<Label>("../Label");
        player.SetPhysicsProcess(true);
        
        label.Text = "";
        label.Visible = true;
        lines = 0;
    }
    public override async void _Process(double delta)
    {
        anim.Play("idle");

        bool interactable = Mathf.Abs(Position.X - player.Position.X) < 110;

        if (interactable)
        {
            Modulate = new Color(1, 1, 0.6f, 1);

            if (Input.IsActionJustPressed("interact"))
            {
                label.Visible = true;
                player.SetPhysicsProcess(false);
                for (int i = 0; i <= 2; i++){
                    GD.Print("one tick.");
                    lines++;
                    updateLabel();
                    await Wait(2.0f);
                }
                await Wait(2.0f);
                GetTree().ChangeSceneToFile("res://Scenes/final/final.tscn");
            }
        }
        else
        {
            Modulate = new Color(1, 1, 1, 1);
        }
    }
    
    public void updateLabel(){
        if (lines == 1){
            label.Text = "Excuse me...";
        }
        if (lines == 2){
            label.Text = "Excuse me...\nWhere can I find";
        }
        if (lines == 3){
            label.Text = "Excuse me...\nWhere can I find\na box of razors?";
        }
    }

    public async Task Wait(float seconds)
    {
        var timer = GetTree().CreateTimer(seconds);
        await ToSignal(timer, "timeout");
    }


}
