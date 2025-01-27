using Godot;
using System;

public partial class NodeSpawner : Node
{
	Node2D ore;
	
	public override void _Ready()
	{
		ore = (Node2D)GetParent();
		SpawnOres();

	}
	
	private void SpawnOres()
	{
		/*for (int i = 1; i < ore.GetChildren().Size()-2; i++)
		{
			
		}*/
	}
}
