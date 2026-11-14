using Godot;
using System;

public partial class CollectiblesHud : CanvasLayer
{
	[Export] private Label _collectedLabel;
	
	public void UpdateLabel(int collected)
	{
		_collectedLabel.Text = $"Apples: {collected}";
	}
}
