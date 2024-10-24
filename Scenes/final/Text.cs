using Godot;
using System;

public partial class Text : Label
{
    private Button _button;
	public int buttonPresses = 0;
	Sprite2D portrait;
	Sprite2D theCount;
	
    public override void _Ready()
    {
		portrait = GetNode<Sprite2D>("../../Portrait");
		theCount = GetNode<Sprite2D>("../../TheCount");

        _button = GetNode<Button>("../Button");
        _button.Pressed += OnButtonPressed;
		Text = @"";	

		theCount.Visible = false;
    }

    public override void _Process(double delta)
    {
    }

    public void OnButtonPressed()
    {
		buttonPresses += 1;
		changeText();

		if (buttonPresses == 4){
			portrait.Visible = false;
		} else if (buttonPresses == 5){
			theCount.Visible = true;
		} else if (buttonPresses == 6){
			theCount.Visible = false;
			Text = "";
		}
	}

	public void changeText(){
		if (buttonPresses == 1){
			Text = @"Suicide is the second-leading cause of death for teens and young adults.";
		} else if (buttonPresses == 2){
			Text = @"Suicide is the second-leading cause of death for teens and young adults.

			1 in 5 high school students seriously consider suicide.";
		} else if (buttonPresses == 3){
			Text = @"Suicide is the second-leading cause of death for teens and young adults.

			1 in 5 high school students seriously consider suicide.

			1 in 10 attempt it.";
    	}	else if (buttonPresses == 4){
			Text = @"





			1 in 10 attempt it.";
    	} else if (buttonPresses == 7){
			portrait.Visible = true;
			Text = @"Is the 2 in 10 someone you know?";
		} else if (buttonPresses == 8){
			Text = @"Is the 2 in 10 ";
		} else if (buttonPresses == 9){
			Text = @"Is the 2 in 10 you?";
		} else if (buttonPresses == 10){
			Text = "";
		} else if (buttonPresses == 11){
			Text = @"Even if a friend isn't there...";
		} else if (buttonPresses == 12){
			Text = @"Even if a friend isn't there...
			Even if family isn't there...";
		} else if (buttonPresses == 13){
			Text = @"Even if a friend isn't there...
			Even if family isn't there...
			Even if a trusted adult isn't there...";
		} else if (buttonPresses == 14){
			Text = @"Someone is always there.";
		} else if (buttonPresses == 15){
			Text = "";
			portrait.Visible = false;
			theCount.Visible = false;
		} else if (buttonPresses == 16){
			GetTree().ChangeSceneToFile("res://Scenes/finalPlusOne/finalPlusOne.tscn");
		}
	}
}
