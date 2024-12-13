using Godot;
using System;

public partial class Balls : Node2D
{
    // Called when the node enters the scene tree for the first time.

    PackedScene ballScene;

    //Load the ball and add the timer in the code
    public override void _Ready()
    {
        ballScene = ResourceLoader.Load<PackedScene>("res://scenes/ball.tscn");
        var Timer = GetNode<Timer>("ballTimer");
        Timer.Timeout -= _on_timer_timeout;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.

    //Start the timer once the ball is dropped
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("drop_ball"))
        {
            GetNode<Timer>("ballTimer").Start();
        }
    }

    //Once the timer is done spawn another ball after 1.5 seconds
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
