using ISX.Processors;

namespace ISX
{
    /// <summary>
    /// A two-axis thumbstick control that can act as both a vector and a four-way dpad.
    /// </summary>
    /// <remarks>
    /// State-wise this is still just a Vector2.
    ///
    /// Unlike <see cref="DpadControl">D-Pads</see>, sticks will usually have <see cref="DeadzoneProcessor">
    /// deadzone processors</see> applied to them.
    /// </remarks>
    public class StickControl : Vector2Control
    {
        [InputControl(useStateFrom = "y", parameters = "clamp,clampMin=0,clampMax=1")]
        public ButtonControl up { get; private set; }
        [InputControl(useStateFrom = "y", parameters = "clamp,clampMin=-1,clampMax=0,invert")]
        public ButtonControl down { get; private set; }
        [InputControl(useStateFrom = "x", parameters = "clamp,clampMin=-1,clampMax=0,invert")]
        public ButtonControl left { get; private set; }
        [InputControl(useStateFrom = "x", parameters = "clamp,clampMin=0,clampMax=1")]
        public ButtonControl right { get; private set; }

        protected override void FinishSetup(InputControlSetup setup)
        {
            up = setup.GetControl<ButtonControl>(this, "up");
            down = setup.GetControl<ButtonControl>(this, "down");
            left = setup.GetControl<ButtonControl>(this, "left");
            right = setup.GetControl<ButtonControl>(this, "right");

            base.FinishSetup(setup);
        }
    }
}
