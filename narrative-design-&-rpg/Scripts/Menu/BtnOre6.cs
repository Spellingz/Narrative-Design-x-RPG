using Godot;
using System;

public partial class BtnOre6 : Button
{
	private void _SwitchMat6()
	{
		Global g = (Global)GetNode("/root/GM");
		g.KaldOreMetode(6);
	}
}
