namespace ScalePad.Core;

public interface IControllerSource
{
    bool TryGetState(out ControllerSnapshot snapshot);
}
