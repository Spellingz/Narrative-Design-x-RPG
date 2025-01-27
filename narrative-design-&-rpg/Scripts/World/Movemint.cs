using Godot;
using System;
public partial class Movemint : CharacterBody2D
{
	public const float Speed = 450.0f;
	AnimatedSprite2D anim;
	Global g;

	public override void _Ready()
	{
		anim =  GetNode<AnimatedSprite2D>("PlayerAnim");
		g = (Global)GetNode("/root/GM");
		anim.Play("Idle");
		GD.Print("Player is ready");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("Right", "Left", "Up", "Down");
		if (direction != Vector2.Zero)
		{
			if (!g.Typing)
			{
				velocity.X = direction.X * Speed;
				velocity.Y = direction.Y * Speed;
				Animate(1, velocity.X, velocity.Y);
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(0, 0, 0);
			velocity.Y = Mathf.MoveToward(0, 0, 0);
			Animate(0, velocity.X, velocity.Y);
		}
		if (!g.Typing)
			{
			Velocity = velocity;
			MoveAndSlide();
		}
	}
	
	private void Animate(int state, float dirX, float dirY)
	{
		if (state == 1)
		{
			if (dirY >= 0.0)
			{
				if (dirX < 0.0)
					anim.FlipH = true;
				if (dirX > 0.0)
					anim.FlipH = false;
				anim.Play("walkSide");
			}
			if (dirY < 0.0)
			{
				if (dirX < 0.0)
					anim.FlipH = true;
				if (dirX > 0.0)
					anim.FlipH = false;
				anim.Play("walkUp");
			}
		}
		else
		{
			anim.Play("Idle");
		}
	}
}
