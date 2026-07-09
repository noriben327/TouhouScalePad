namespace TouhouScaleChanger.Core;

public interface IControllerSource
{
    bool TryGetState(out ControllerSnapshot snapshot);
}
