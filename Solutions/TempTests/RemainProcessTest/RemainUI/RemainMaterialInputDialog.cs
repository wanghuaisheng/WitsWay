using System;
using DevExpress.XtraEditors;
using WitsWay.Utilities.Attributes;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.TempTests.RemainProcessTest.RemainUI
{

    /// <summary>
    /// 条码输入对话框
    /// </summary>
    public partial class RemainMaterialInputDialog : XtraForm
    {
        /// <summary>
        /// 余料
        /// </summary>
        public RemainItem Remain { get; set; }

        /// <summary>
        /// 所有支持的原材料
        /// </summary>
        //public List<MaterialConfigItem> Materials { get; set; }

        public Predicate<string> VerifyInputValueCallback;
    /// <summary>
        /// 构造函数
        /// </summary>
        public RemainMaterialInputDialog()
        {
            InitializeComponent();
            InitControls();
        }
        ///// <summary>
        ///// 构造函数
        ///// </summary>
        //public RemainMaterialInputDialog(List<MaterialConfigItem> mats)
        //{
        //    Materials = mats;
        //    InitializeComponent();
        //    InitControls();
        //}

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            ButtonStyleHelper.StyleButton(_btnClose, ButtonStyles.Close, _btnClose.Width, _btnClose.Text, true, _btnClose.Height);
            ButtonStyleHelper.StyleButton(_btnOk, ButtonStyles.Confirm, _btnOk.Width, _btnOk.Text, true, _btnOk.Height);
            _radioInputWay.EditValue = (int)RemainInputWay.Scan;
            ReadOnlyInputControls();
            SpinEditHelper.SetSpinEditStyle(_spinWidth, 1, 0, 10000);
            SpinEditHelper.SetSpinEditStyle(_spinLength, 1, 0, 10000);
        }

        private void ReadOnlyInputControls()
        {
            _comboMaterial.Properties.ReadOnly = true;
            _spinWidth.Properties.ReadOnly = true;
            _spinLength.Properties.ReadOnly = true;
        }

        private void EnableInputControls()
        {
            _comboMaterial.Properties.ReadOnly = false;
            _spinWidth.Properties.ReadOnly = false;
            _spinLength.Properties.ReadOnly = false;
        }

        private void RemainMaterialInputDialog_Load(object sender, EventArgs e)
        {
            BindControls();
            _radioInputWay.SelectedIndexChanged += _radioInputWay_SelectedIndexChanged;
        }

        void _radioInputWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            var inputWay = (RemainInputWay)_radioInputWay.EditValue;
            if (inputWay == RemainInputWay.Scan)
            {
                ReadOnlyInputControls();
            }
            else
            {
                EnableInputControls();
            }

        }

        /// <summary>
        /// 绑定控件
        /// </summary>
        private void BindControls()
        {
            _spinWidth.EditValue = 0M;
            _spinLength.EditValue = 0M;
            //ComboBoxHelper.BindListToCombo(_comboMaterial, Materials, m => m.Name, "选择原材料");
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            EnterClick();
        }

        private void EnterClick()
        {
            //UtilityHelper.ShowInfoMessage("开始匹配加工板件");

            RemainProcessForm frm=new RemainProcessForm();
            frm.ShowDialog(this);
            //            var inputValue = "";
            //
            //            if (string.IsNullOrWhiteSpace(inputValue))
            //            {
            //                UtilityHelper.ShowWarningMessage(EnumField.GetFieldText(_barCode) + "不能为空。");
            //                return;
            //            }
            //
            //            if (
            //                TcncExceptionHelper.HandleException(
            //                    () => VerifyInputValueCallback == null || VerifyInputValueCallback(inputValue)))
            //            {
            //                BarCode = inputValue.Trim();
            //                DialogResult = DialogResult.OK;
            //            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            RemainProcessForm2 frm = new RemainProcessForm2();
            frm.ShowDialog(this);
        }

    }

    /// <summary>
    /// 余料想
    /// </summary>
    public class RemainItem
    {
        public string Material { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }
    }

    /// <summary>
    /// 余料录入方式
    /// </summary>
    public enum RemainInputWay
    {

        /// <summary>
        /// 扫码录入
        /// </summary>
        [EnumField("扫码")]
        Scan = 1,

        /// <summary>
        /// 手动输入
        /// </summary>
        [EnumField("输入")]
        Input = 2

    }
}
