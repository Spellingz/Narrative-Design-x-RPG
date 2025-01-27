using Godot;
using System;

public partial class BtnOre7 : Button
{
	private void _SwitchMat7()
	{
		Global g = (Global)GetNode("/root/GM");
		g.KaldOreMetode(7);
	}
}
