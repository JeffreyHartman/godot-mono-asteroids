using Godot;
using System;

public class player : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private const int TurnSpeed = 180;
    private const int MoveSpeed = 150;
    private const float Acc = 0.05f;
    private const float Dec = 0.01f;
    private Vector2 motion = new Vector2(0, 0);
    private Vector2 screenSize;
    private int screenBuffer = 8;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Input.IsActionPressed("ui_left"))
        {
            RotationDegrees -= TurnSpeed * delta;
        }

        if(Input.IsActionPressed("ui_right"))
        {
            RotationDegrees += TurnSpeed * delta;
        }

        var vector = new Vector2(1, 0);
        var moveDir = vector.Rotated(Rotation);

        if(Input.IsActionPressed("ui_up"))
        {
            motion = motion.LinearInterpolate(moveDir, Acc);
        } else
        {
            motion = motion.LinearInterpolate(new Vector2(0, 0), Dec);
        }

        Position += motion * MoveSpeed * delta;


        var x = Godot.Mathf.Wrap(Position.x, -screenBuffer, screenSize.x + screenBuffer);
        var y = Godot.Mathf.Wrap(Position.y, -screenBuffer, screenSize.y + screenBuffer);
        Position = new Vector2(x, y);
            
    }    
}
