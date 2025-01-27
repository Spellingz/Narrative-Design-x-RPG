using Godot;
using System;

public partial class Equip2 : Button
{
	private void _OnEquip()
	{
		Global g = (Global)GetNode("/root/GM");
		g.Equip(1);
	}
}
