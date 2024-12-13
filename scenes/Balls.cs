using Godot;
using System;

public partial class Balls : Node2D
{
    // Called when the node enters the scene tree for the first time.

    PackedScene ballScene;
    public override void _Ready()
    {
        ballScene = ResourceLoader.Load<PackedScene>("res://scenes/ball.tscn");
        var Timer = GetNode<Timer>("ballTimer");
        Timer.Timeout -= _on_timer_timeout;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("drop_ball"))
        {
            GetNode<Timer>("ballTimer").Start();
        }
    }

    public void _on_timer_timeout()
    {
        var newBall = ballScene.Instantiate<RigidBody2D>();

        AddChild(newBall);
        newBall.Position = new Vector2(935, 85);

        newBall.Name = "ball";
        GD.Print("Timer Ended");
        GetNode<Timer>("ballTimer").Stop();
    }
}
