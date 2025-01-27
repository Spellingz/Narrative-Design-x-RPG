using Godot;
using System;

public partial class UIClose : Button
{
	public override void _Ready()
	{
		//GetParent<Control>().Visible = false;
		//GetNode<Control>("../Forge_Menu").Visible = false;
	}
	
	private void _btnClose()
	{
		GetParent<Control>().Visible = false;
		Global g = (Global)GetNode("/root/GM");
		g.Typing = false;
	}
}
