using Godot;
using System;

public partial class BtnOre2 : Button
{
	private void _SwitchMat2()
	{
		Global g = (Global)GetNode("/root/GM");
		g.KaldOreMetode(2);
	}
}
