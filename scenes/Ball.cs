using Godot;
using System;

public partial class Ball : RigidBody2D
{
    // Called when the node enters the scene tree for the first time.
    //variable for the speed
    [Export]
    public float ballSpeed = 1.0f;

    //variable for the score label
    [Export]
    public Label scoreLabel;

    // add a variable to keep score of the points the player gets
    public int score = 0;

    public int scoreValue = 50;

    public override void _Ready()
    {
        Freeze = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        //Add controls to move the ball left and right
        if (Freeze)
        {
            float xMovement = Input.GetAxis("left", "right");

            float xChange = xMovement * ballSpeed * (float)delta;

            Vector2 newPos = new Vector2(Position.X + xChange, Position.Y);

            Position = newPos;
        }

        //Add controls to drop the ball 
        if (Input.IsActionJustPressed("drop_ball"))
        {
            Freeze = false;
        }
        
        //Displays the amount of points the player has on screen
        scoreLabel.Text = $"Score: {score}";
    }

    //Removes the balls from the screen once they touch eachother
    public void _on_area_2d_area_entered(Node RigidBody2D)
    {        
        QueueFree();
    }
}
