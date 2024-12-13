using Godot;
using System;

public partial class Ball : RigidBody2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public float ballSpeed = 1.0f;

    public override void _Ready()
    {
        Freeze = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Freeze)
        {
            float xMovement = Input.GetAxis("left", "right");

            float xChange = xMovement * ballSpeed * (float)delta;

            Vector2 newPos = new Vector2(Position.X + xChange, Position.Y);

            Position = newPos;
        }

        if (Input.IsActionJustPressed("drop_ball"))
        {
            Freeze = false;
        }
    }
    public void _on_area_2d_area_entered(Node RigidBody2D)
    {
        QueueFree();
    }
}
