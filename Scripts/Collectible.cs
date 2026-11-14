using Godot;

public partial class Collectible : Area2D
{
	[Export] public int Value = 1;
	
	[Export] private AudioStreamPlayer2D _collectSound;

	private AnimatedSprite2D _sprite;
	private CollisionShape2D _shape;
	private bool _collected = false;

	public override void _Ready()
	{
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_shape = GetNode<CollisionShape2D>("CollisionShape2D");

		_sprite.Play("idle");

		BodyEntered += OnBodyEntered;
		_sprite.AnimationFinished += OnAnimationFinished;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (_collected) return;

		if (body is CharacterBody2d player)
		{
			_collected = true;
			player.AddCollectible(Value);

			_shape.SetDeferred(CollisionShape2D.PropertyName.Disabled, true);

			_sprite.Play("pickup");
			_collectSound.Play();
		}
	}

	private void OnAnimationFinished()
	{
		if (_sprite.Animation == "pickup")
			QueueFree();
	}
}
