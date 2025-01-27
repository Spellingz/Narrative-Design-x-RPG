using Godot;
using System;

public partial class Inventory : Button
{
	Global g;
	Control inv;
	
	public int temp;
	
	public override void _Ready()
	{
		g = (Global)GetNode("/root/GM");
		inv = (Control)GetNode("/root/World/UI/UI/Inventory");
	}
	
	public void _OnInvPressed()
	{
		if (inv.Visible == true)
			inv.Visible = false;
		else
			inv.Visible = true;
		g.UpdateInv();
	}
}
