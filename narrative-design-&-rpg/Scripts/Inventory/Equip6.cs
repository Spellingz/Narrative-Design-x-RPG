using Godot;
using System;

public partial class Equip6 : Button
{
	private void _OnEquip()
	{
		Global g = (Global)GetNode("/root/GM");
		g.Equip(5);
	}
}
