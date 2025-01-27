using Godot;
using System;

public partial class BtnOre1 : Button
{
	private void _SwitchMat1()
	{
		Global g = (Global)GetNode("/root/GM");
		g.KaldOreMetode(1);
	}
}
