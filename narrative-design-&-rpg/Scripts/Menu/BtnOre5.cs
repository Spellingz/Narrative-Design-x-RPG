using Godot;
using System;

public partial class BtnOre5 : Button
{
	private void _SwitchMat5()
	{
		Global g = (Global)GetNode("/root/GM");
		g.KaldOreMetode(5);
	}
}
