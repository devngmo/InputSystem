using System;
using ISX.LowLevel;
using UnityEngine;

namespace ISX
{
    public class Vector3Control : InputControl<Vector3>
    {
        [InputControl(offset = 0)]
        public AxisControl x { get; private set; }
        [InputControl(offset = 4)]
        public AxisControl y { get; private set; }
        [InputControl(offset = 8)]
        public AxisControl z { get; private set; }

        public Vector3Control()
        {
            m_StateBlock.format = InputStateBlock.kTypeVector3;
        }

        protected override void FinishSetup(InputControlSetup setup)
        {
            x = setup.GetControl<AxisControl>(this, "x");
            y = setup.GetControl<AxisControl>(this, "y");
            z = setup.GetControl<AxisControl>(this, "z");
            base.FinishSetup(setup);
        }

        protected override Vector3 ReadRawValueFrom(IntPtr statePtr)
        {
            return new Vector3(x.ReadValueFrom(statePtr), y.ReadValueFrom(statePtr), z.ReadValueFrom(statePtr));
        }
    }
}
