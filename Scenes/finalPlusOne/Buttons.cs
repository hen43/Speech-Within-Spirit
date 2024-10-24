using Godot;
using System;
public partial class Buttons : Control
{
    Button _openLink;
    Button _githubLink;

    public override void _Ready()
    {
        _openLink = GetNode<Button>("OpenLink");
        _githubLink = GetNode<Button>("GithubLink");

        _openLink.Pressed += () => OnButtonPressed(_openLink);
        _githubLink.Pressed += () => OnButtonPressed(_githubLink);
    }

	private void OnButtonPressed(Button button)
    {
        if (button == _openLink)
        {
			OS.ShellOpen("https://www.google.com/search?q=988&safe=active&ssui=on");
        }
        else if (button == _githubLink)
        {
			OS.ShellOpen("https://github.com/hen43/Speech-Within-Spirit");
        }
    }

    public override void _Process(double delta)
    {
    }
}
