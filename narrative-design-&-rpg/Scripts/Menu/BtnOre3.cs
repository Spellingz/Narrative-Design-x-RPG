using Godot;
using System;

public partial class BtnOre3 : Button
{
	private void _SwitchMat3()
	{
		Global g = (Global)GetNode("/root/GM");
		g.KaldOreMetode(3);
	}
}
