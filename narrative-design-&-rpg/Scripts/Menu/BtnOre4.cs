using Godot;
using System;

public partial class BtnOre4 : Button
{
	private void _SwitchMat4()
	{
		Global g = (Global)GetNode("/root/GM");
		g.KaldOreMetode(4);
	}
}
