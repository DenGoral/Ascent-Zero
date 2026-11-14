using Godot;

public partial class PauseButtonScene : Node
{
	[Signal] public delegate void PauseRequestedEventHandler();

	[Export] private BaseButton _button;

	public override void _Ready()
	{
		_button.Pressed += () => EmitSignal(SignalName.PauseRequested);
	}
}
