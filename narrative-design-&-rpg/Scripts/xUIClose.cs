using Godot;
using System;

public partial class UIClose : Button
{
	
	public void _Close()
	{
		Global g = (Global)GetNode("/root/GM");
		GetParent<Control>().Visible = false;
		g.Typing = false;
		
	}
}
