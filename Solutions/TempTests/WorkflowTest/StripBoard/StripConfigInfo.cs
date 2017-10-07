using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WitsWay.TempTests.WorkflowTest.StripBoard
{
    public class StripConfigInfo
    {
        [Required(ErrorMessage = @"编码必填", AllowEmptyStrings = false)]
        [Description("编码")]
        [CustomValidation(typeof(StripConfigInfo), "methodAbc", ErrorMessage = "")]
        //[DataType(DataType.Text,WarterMark="请输入",Icon="")]
        //[DataEditor(Editor="Dropdown",Options="123,345,456")]
        [RegularExpression("pattern", ErrorMessage = @"Code不符合格式")]
        public string Code { get; set; }

        public string Name { get; set; }

        public string MaterialIc { get; set; }

        public string MaterialName { get; set; }

        public string CraftIc { get; set; }
        public string CraftName { get; set; }

        //[DataEditor(Editor = typeof(LibItemListUc), Options = "123,345,456")]
        public List<StripUnderUnit> Units { get; set; }

    }

    public class StripUnderUnit
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string CraftIc2 { get; set; }
        public string CraftName2 { get; set; }

        public List<string> BaseUnitGroups { get; set; }

        public List<string> BaseUnitCodes { get; set; }

        public List<string> MaterialCodes { get; set; }

        public List<string> MaterialGroups { get; set; }

        public List<string> CabinetGroups { get; set; }

        public List<string> CabinetCodes { get; set; }

    }

}
