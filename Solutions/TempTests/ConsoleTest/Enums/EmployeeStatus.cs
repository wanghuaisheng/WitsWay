/*******************************************
修改记录:
自动生成(2017-06-19):创建ModuleItemData
********************************************/

using System;

namespace WitsWay.TempTests.ConsoleTest.Enums
{
    [Flags]
    public enum EmployeeStatus
    {
        Removed = 0,
        Enable = 1,
        Confirmed = 2,
        Disable = 4,
        Locked = 8,
        LockLogin = 16
    }
}
