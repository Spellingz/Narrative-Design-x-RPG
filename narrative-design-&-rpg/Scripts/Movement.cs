using Godot;
using System;

public partial class Movement : CharacterBody2D
{
	public const float speed = 90.0f;
	public string current_dir = "none";
	private Vector2 temp;
	AnimatedSprite2D anim;
 
	public override void _Ready()
	{
		
		anim =  GetNode<AnimatedSprite2D>("PlayerAnim");
		anim.Play("IdleF");
		GD.Print("Player is ready");
	}
 
	public override void _PhysicsProcess(double delta)
	{
		PlayerMovement(delta);
	}
 
	public void PlayerMovement(double delta)
	{
		if ( Input.IsKeyPressed(Key.D)){
			current_dir = "right";
			PlayAnimation(1);
			temp = new Vector2(speed,0);
			Velocity = temp;
 
		}
		else if( Input.IsKeyPressed(Key.A)){
			current_dir = "left";
			PlayAnimation(1);
 
			temp = new Vector2(-speed,0);
			Velocity = temp;
		}
		else if( Input.IsKeyPressed(Key.W)) {
			current_dir = "up";
			PlayAnimation(1);
			temp = new Vector2(0, -speed);
			Velocity = temp;
		}
		else if( Input.IsKeyPressed(Key.S)) {
			current_dir = "down";
			PlayAnimation(1);
			temp = new Vector2(0, speed);
			Velocity = temp;
		}
		else if( Input.IsKeyPressed(Key.V)) {
			//DialogManager dm = GetNode<DialogManager>("/root/DialogManager");
			//DialogManager.LoadDialogue("wizard.json");
			//dm.ShowDialogue();
		}
		else if( Input.IsKeyPressed(Key.B)) {
			//DialogManager dm = GetNode<DialogManager>("/root/DialogManager");
			//dm.HideDialogue();
		}
		else {
			PlayAnimation(0);
			Velocity = new Vector2(0,0);
		}
 
		MoveAndSlide();
	}
 
	
	void PlayAnimation(int movement){
 
		string dir = current_dir;
 
		if ( dir == "right" ) {
			anim.FlipH = false;
			if (movement == 1) {
				anim.Play("MoveS");
			}
			else if ( movement == 0 ){
				anim.Play("IdleS");
			}
		}
		else if ( dir == "left") {
			anim.FlipH = true;
			if (movement == 1)
				anim.Play("MoveS");
			else if (movement == 0)
				anim.Play("IdleS");
		}
		else if (dir == "up"){
			if ( movement == 1)
				anim.Play("MoveB");
			else if (movement == 0)
				anim.Play("IdleB");
		}
		else if (dir == "down"){
			if (movement == 1)
				anim.Play("MoveF");
			else if (movement == 0)
				anim.Play("IdleF");
		}
	}
}
