namespace QAutomation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Flags]
    public enum State
    {
        Present =  0000_0001,
        Absent =   0000_0010,
        Enabled =  0000_0100,
        Disabled = 0000_1000,
        ReadyForAction = Present | Enabled,
    }
}
