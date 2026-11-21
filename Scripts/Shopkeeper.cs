using Godot;
using System;

public partial class Shopkeeper : Node
{
	// Exported node references
	[Export] private Area2D _area;
	[Export] private Label _prompt;
	[Export] private CanvasLayer _shopUI;
	[Export] private Button _closeButton;

	private bool _playerInRange = false;

	public override void _Ready()
	{
		_area.BodyEntered += OnBodyEnterred;
		_area.BodyExited += OnBodyExited;
		_closeButton.Pressed += CloseShop;

		_prompt.Visible = false;
		_shopUI.Visible = false;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (_playerInRange && @event.IsActionPressed("interact"))
		{
			OpenShop();
			GetViewport().SetInputAsHandled();
		}
		else if (_shopUI.Visible && @event.IsActionPressed("ui_cancel"))
		{
			CloseShop();
			GetViewport().SetInputAsHandled();
		}
	}

	private void OnBodyEnterred(Node2D body)
	{
		if (body is CharacterBody2D)
		{
			_playerInRange = true;
			_prompt.Visible = true;
		}
	}

	private void OnBodyExited(Node2D body)
	{
		if (body is CharacterBody2D)
		{
			_playerInRange = false;
			_prompt.Visible = false;
			CloseShop();
		}
	}

	private void OpenShop()
	{
		_prompt.Visible = false;
		_shopUI.Visible = true;
	}

	private void CloseShop()
	{
		_shopUI.Visible = false;

		if (_playerInRange)
		{
			_prompt.Visible = true;
		}
	}
}
