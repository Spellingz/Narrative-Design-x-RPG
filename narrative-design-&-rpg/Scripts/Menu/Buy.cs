using Godot;
using System;

public partial class Buy : Button
{
	Global g;
	
	Control type;
	public int nr;
	public bool allowed = false;
	
	// Switch Case Values
	public string pickName;
	public int pickLvl;
	public int[] matCost = new int[8]; // [ Coins, Missium, Blurium, Topazium, Azurium, Crimsonium, Jadium, GoDot-ium ]
	public int tempCounter;
	
	public override void _Ready()
	{
		g = (Global)GetNode("/root/GM");
	}
	
	public void _OnPressed()
	{
		type = (Control)GetParent();
		nr = int.Parse(type.Name.ToString().Substring(4));
		
		// SWITCH CASE
		switch(nr)
		{
			case 0:
				pickName = "Starter Pickaxe";
				matCost = new int[] {0,0,0,0,0,0,0,0};
				break;
			case 1:
				pickName = "Blurium Pickaxe";
				matCost = new int[] {500,15,10,0,0,0,0,0};
				break;
			case 2:
				pickName = "Topazium Pickaxe";
				matCost = new int[] {1000,0,15,10,0,0,0,0};
				break;
			case 3:
				pickName = "Azurium Pickaxe";
				matCost = new int[] {1500,0,0,15,10,0,0,0};
				break;
			case 4:
				pickName = "Crimsonium Pickaxe";
				matCost = new int[] {2500,0,0,0,15,10,0,0};
				break;
			case 5:
				pickName = "GALAXY Pickaxe";
				matCost = new int[] {10000,15,15,15,15,15,15,0};
				break;
			default:
				pickName = "default";
				matCost = new int[] {0,0,0,0,0,0,0,0};
				break;
		}
		BuyPick();
	}
	
	private void BuyPick()
	{
		if (g.picks[nr] == 0)
		{
			if (g.coins >= matCost[0])
			{
				for (int i = 1; i <= g.mats.Length-1; i++)
				{
					if (g.mats[i] >= matCost[i])
					{
						tempCounter++;
					}
				}
				if (tempCounter >= matCost.Length-1)
					allowed = true;
				else
					allowed = false;
				tempCounter = 0;
				
			}
		}
		
		if (allowed == true)
		{
			g.coins -= matCost[0];
			for (int i = 1; i <= g.mats.Length-1; i++)
			{
				g.mats[i] -= matCost[i];
			}
			GD.Print(g.picks[nr]);
			g.picks[nr] = 1;
			GD.Print(g.picks[nr]);
			for (int i = 0; i <= g.picks.Length-1; i++)
			{
				GD.Print("pick" + i + ": " + g.picks[i]);
			}
			g.UpdateUI("mats");
			g.UpdateUI("pick");
			g.UpdateUI("shop");
			allowed = false;
		}
		else
			GD.Print("False");
	}
}
