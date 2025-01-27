using Godot;
using System;

public partial class btnMenuSell1 : Button
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private void _btnSell()
	{
		Global g = (Global)GetNode("/root/GM");
		SpinBox val = (SpinBox)GetNode("/root/World/UI/UI/Sell_Menu/ColorRect2/SpinBox2");
		if ( g.mats[g.mat]-val.Value >= 0) 
		{
			g.coins += int.Parse(g.sellPrice.ToString()) * int.Parse(val.Value.ToString());
			g.mats[g.mat] -= int.Parse(val.Value.ToString());
		}
		for (int i = 1; i <=7; i++)
		{
			GD.Print(g.mats[i]);
		}
		GD.Print("coins: " + g.coins.ToString());
		g.UpdateUI("mats");
	}
	
	private void CounterChanged(double num)
	{
		GD.Print(num);
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		/*Global g = (Global)GetNode("/root/Globals/GM");
		Label lblPrice = (Label)GetNode("lblPrice");
		lblPrice.Text = g.coins.ToString();*/
	}
}
