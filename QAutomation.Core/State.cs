namespace QAutomation.Core
{
    using System;

    [Flags]
    public enum State
    {
        None = 0,
        Present =  0000_0001,
        Absent =   0000_0010,
        Enabled =  0000_0100,
        Disabled = 0000_1000,
        ReadyForAction = Present | Enabled,
    }
}
