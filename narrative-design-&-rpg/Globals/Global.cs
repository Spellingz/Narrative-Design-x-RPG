using Godot;
using System;

public partial class Global : Node
{
	Button equipBut;
	Button oldEquipBut;
	Control inv;
	
	// UI vars
	public string[] matName = {"x", "Pissium", "Blurium", "Topazium", "Azurium", "Crimsonium", "Jadeium", "GoDotium"};
	
	// Player vars
	public int coins = 0;
	public int[] mats = {0, 50, 50, 50, 50, 50, 50, 50};
	public int[] picks = {1, 1, 0, 0, 0, 0};
	public int pickLvl;
	public bool Typing;
	
	// Menu vars
	public string orename;
	public int sellPrice;
	public int mat;
	public int old;
	
	// Other vars
	public bool inUse = false;
	
	public override void _Ready()
	{
		old = 0;
		inv = (Control)GetNode("/root/World/UI/UI/Inventory");
		equipBut = (Button)GetNode("/root/World/UI/UI/Inventory/Slot"+old+"/Equip");
		equipBut.Text = "Equipped";
		picks[old] = 2;
		UpdateUI("mats");
		UpdateUI("pick");
		UpdateInv();
	}
	
	public void KaldOreMetode(int ore)
	{
		switch(ore)
		{
			//Name = "x"; Missium, Blurium, Topazium, Azurium, Crimsonium, Jadium, GoDot-ium 
			//Sell Price = x; Selling Price
			//mat = x; Number of material
			case 1:
				orename = "Missium";
				sellPrice = 50;
				mat = 1;
				break;
			case 2:
				orename = "Blurium";
				sellPrice = 100;
				mat = 2;
				break;
			case 3:
				orename = "Topazium";
				sellPrice = 200;
				mat = 3;
				break;
			case 4:
				orename = "Azurium";
				sellPrice = 350;
				mat = 4;
				break;
			case 5:
				orename = "Crimsonium";
				sellPrice = 500;
				mat = 5;
				break;
			case 6:
				orename = "Jadium";
				sellPrice = 700;
				mat = 6;
				break;
			case 7:
				orename = "GoDotium";
				sellPrice = 1000;
				mat = 7;
				break;
			default:
				orename = "placeholder";
				sellPrice = 100;
				mat = 0;
				pickLvl = 0;
				break;
		}
		GD.Print(orename);
		Label lblPrice = (Label)GetNode("/root/World/UI/UI/Sell_Menu/ColorRect2/lblPrice2");
		Label lblMat = (Label)GetNode("/root/World/UI/UI/Sell_Menu/ColorRect2/lblMat2");
		lblMat.Text = orename;
		lblPrice.Text = sellPrice.ToString() + " Coins";
		UpdateUI("mats");
	}
	public void UpdateUI(string type)
	{
		Label Coins = (Label)GetNode("/root/World/UI/UI/UI/lblCoins");
		Label Pick = (Label)GetNode("/root/World/UI/UI/UI/lblPick");
		Control Mats = (Control)GetNode("/root/World/UI/UI/UI/Mats");
		Control shops = (Control)GetNode("/root/World/UI/UI/Forge_Menu");
		var matsd = Mats.GetChildren();
		
		if (type == "mats")
		{
			Coins.Text = "Coins: " + coins.ToString();
			for (int i = 0; i <= 6; i++)
			{
				((Label)matsd[i]).Text = matName[i+1] + ": " + mats[i+1].ToString();
			}
		}
		if (type == "pick")
		{
			for (int i = 0; i <= picks.Length-1; i++)
			{
				if (picks[i] == 2)
					pickLvl = i+1;
			}
			Pick.Text = "Pick Level: " + pickLvl;
		}
		if (type == "shop")
		{
			Button shopSlot;
			for (int i = 1; i <= 5; i++)
			{
				shopSlot = (Button)GetNode("/root/World/UI/UI/Forge_Menu/Slot"+i+"/Buy");
				if (picks[i] != 0)
				{
					shopSlot.Text = "Bought"; 
					shopSlot.Disabled = true;
				}
				else
				{
					shopSlot.Text = "Buy"; 
					shopSlot.Disabled = false;
				}
			}
		}
		GD.Print("Finished Updating UI");
	}
	public void UpdateInv()
	{
		for (int i = 0; i <= picks.Length; i++)
		{
			foreach (Control invChild in inv.GetChildren())
			{
				if (invChild.Name.ToString().Substring(4) == i.ToString())
				{
					if (picks[i] == 0)
						invChild.Visible = false;
					if (picks[i] == 1 || picks[i] == 2)
						invChild.Visible = true;
				}
			}
		}
		UpdateUI("pick");
	}
	public void Equip(int nr)
	{
		GD.Print("slot"+nr+": " + picks[nr]);
		if (picks[nr] == 1)
		{
			GD.Print("nr: " + nr);
			GD.Print("old: " + old);
			equipBut = (Button)GetNode("/root/World/UI/UI/Inventory/Slot"+nr+"/Equip");
			equipBut.Text = "Equipped";
			picks[nr] = 2;
			
			oldEquipBut = (Button)GetNode("/root/World/UI/UI/Inventory/Slot"+old+"/Equip");
			oldEquipBut.Text = "Equip";
			picks[old] = 1;

			old = nr;
			UpdateInv();
			
		}
	}
}
