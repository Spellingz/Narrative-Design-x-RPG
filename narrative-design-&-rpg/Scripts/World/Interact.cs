using Godot;
using System;

public partial class Interact : Area2D
{
	Global g;
	Control Sell;
	TextureRect interact;
	Control Forge;
	TextureRect ore;
	TextureRect oldOre;
	Label Mining;
	
	public string oreName;
	public string menu;
	public bool mine;
	public double mineDura = 0d;
	public double oreRespawn = 0d;
	public int pickLvl;

	
	public override void _Ready()
	{
		Mining = (Label)GetNode("/root/World/UI/UI/UI/Mining");
		Sell = (Control)GetNode("/root/World/UI/UI/Sell_Menu");
		Forge = (Control)GetNode("/root/World/UI/UI/Forge_Menu");
		interact = (TextureRect)GetParent();
		g = (Global)GetNode("/root/GM");
		ore = (TextureRect)GetNode("/root/World/Map/Nodes/Placeholder");
		oldOre = (TextureRect)GetNode("/root/World/Map/Nodes/Placeholder");
	}
	public void _OnEnter(Node2D body)
	{
		if (body.Name == "Player")
		{
			menu = GetParent().GetParent().Name;
			ore = (TextureRect)GetParent().GetParent();
			interact.Visible = true;
			GD.Print(menu);
		}
	}
	public void _OnExit(Node2D body)
	{
		if (body.Name == "Player")
		{
			menu = "default";
			Sell.Visible = false;
			interact.Visible = false;
			g.Typing = false;
			GD.Print("DeSuccess");
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("Interact") && interact.Visible == true)
		{
			if (menu == "Shop")
			{
				if (Sell.Visible == false)
				{
					Sell.Visible = true;
					g.Typing = true;
				} else {
					Sell.Visible = false;
					g.Typing = false;
				}
			}
			if (menu == "Forge")
			{
				if (!Forge.Visible)
				{
					Forge.Visible = true;
					g.Typing = true;
				} else {
					Forge.Visible = false;
					g.Typing = false;
				}
				g.UpdateUI("shop");
			}
			if (menu.StartsWith("ore"))
			{
				string tempPickLvl = ore.Name.ToString();
				int tempPickLvlx = (int)(tempPickLvl[3]-'0');
				if (g.Typing == false && mineDura <= 0 && oreRespawn <= 0 && g.pickLvl >= tempPickLvlx)
				{
					g.Typing = true;
					mine = true;
					Mining.Visible = true;
					mineDura = 3.0d;
				}
				else
				{
					g.Typing = false;
					Mining.Visible = false;
					mineDura = 0;
					mine = false;
				}
				
			}
		}
		if (mineDura > 0 && mine == true)
			mineDura -= delta;
		if (mineDura <= 0 && mine == true)
		{
			g.Typing = false;
			ore.Visible = false;
			oreName = menu[3].ToString();
			oldOre = (TextureRect)ore;
			g.mats[int.Parse(oreName)]++;
			oreRespawn = 5.0;
			mine = false;
			Mining.Visible = false;
			g.UpdateUI("mats");
		}
		if (oreRespawn > 0)
			oreRespawn -= delta;
		if (oreRespawn <= 0.0 && oldOre.Visible == false)
			oldOre.Visible = true;
	}
}
