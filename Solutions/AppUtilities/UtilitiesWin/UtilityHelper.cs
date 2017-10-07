using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Exceptions;
using WitsWay.Utilities.Guards;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Win.Controls;
using WitsWay.Utilities.Win.Helpers;
using WitsWay.Utilities.Win.Properties;

namespace WitsWay.Utilities.Win
{
    /// <summary>
    /// WinForm通用辅助类
    /// </summary>
    public static class UtilityHelper
    {
        private static volatile bool _showWait = true;

        /// <summary>
        /// 异步调用方法
        /// </summary>
        public static object ShowWait(object service, string method, string title = "请稍后…", params object[] parameters)
        {
            var serviceType = service.GetType();
            var callMethod = serviceType.GetMethod(method);
            if (callMethod == null)
            {
                throw new ArgumentException($"未能在 {serviceType} 中找到方法 {method} 。");
            }

            var frmWait = new WaitForm(title);

            object returnValue = null;
            Exception callException = null;
            _showWait = true;
            var threadStart = new ThreadStart(() =>
            {
                var start = DateTime.Now;
                try
                {
                    returnValue = callMethod.Invoke(service, parameters);
                }
                catch (Exception ex)//异常回归主线程
                {
                    callException = ex;
                }
                finally
                {
                    if (DateTime.Now.Subtract(start).Milliseconds < 300)
                    {
                        _showWait = false;
                    }
                    else if (DateTime.Now.Subtract(start).Milliseconds < 500)
                    {
                        System.Threading.Thread.Sleep(300);
                    }
                    frmWait.DialogResult = DialogResult.OK;
                }
            });
            var thread = new System.Threading.Thread(threadStart);
            thread.Start();
            while (!thread.IsAlive){}
            System.Threading.Thread.Sleep(300);
            if (_showWait)
            {
                frmWait.ShowDialog();
                frmWait.Close();
            }
            if (callException != null)//主线程抛出异常
            {
                throw ExceptionHelper.GetInnerException(callException);
            }
            return returnValue;
        }

        /// <summary>
        /// 异步调用方法
        /// </summary>
        public static void ShowWait(Action action, string title = "请稍后…")
        {
            var frmWait = new WaitForm(title);
            Exception callException = null;
            _showWait = true;
            var threadStart = new ThreadStart(() =>
            {
                var start = DateTime.Now;
                try
                {
                    action();
                }
                catch (Exception ex)//异常回归主线程
                {
                    callException = ex;
                }
                finally
                {
                    if (DateTime.Now.Subtract(start).Milliseconds < 300)
                    {
                        _showWait = false;
                    }
                    else if (DateTime.Now.Subtract(start).Milliseconds < 500)
                    {
                        System.Threading.Thread.Sleep(300);
                    }
                    frmWait.DialogResult = DialogResult.OK;
                }
            });
            var thread = new System.Threading.Thread(threadStart);
            thread.Start();
            while (!thread.IsAlive){}
            System.Threading.Thread.Sleep(300);
            if (_showWait)
            {
                frmWait.ShowDialog();
                frmWait.Close();
            }
            if (callException != null)//主线程抛出异常
            {
                throw ExceptionHelper.GetInnerException(callException);
            }
        }

        /// <summary>
        /// 异步调用方法
        /// </summary>
        public static void ShowWait(Action action, Action successAction, string title = "请稍后…")
        {
            ArgumentGuard.ArgumentNotNull("action", action);
            var frmWait = new WaitForm(title);
            Exception callException = null;
            _showWait = true;
            ThreadStart threadStart = () =>
            {
                var start = DateTime.Now;
                try
                {
                    action();
                    successAction?.Invoke();
                }
                catch (Exception ex)//异常回归主线程
                {
                    callException = ex;
                }
                finally
                {
                    if (DateTime.Now.Subtract(start).Milliseconds < 300)
                    {
                        _showWait = false;
                    }
                    else if (DateTime.Now.Subtract(start).Milliseconds < 500)
                    {
                        System.Threading.Thread.Sleep(300);
                    }
                    frmWait.DialogResult = DialogResult.OK;
                }
            };
            var thread = new System.Threading.Thread(threadStart);
            thread.Start();
            while (!thread.IsAlive){}
            System.Threading.Thread.Sleep(300);
            if (_showWait)
            {
                frmWait.ShowDialog();
                frmWait.Close();
            }
            if (callException != null)//主线程抛出异常
            {
                throw ExceptionHelper.GetInnerException(callException);
            }
        }


        /// <summary>
        /// 异步调用方法
        /// </summary>
        public static T ShowWait<T>(Func<T> func, string title = "请稍后…")
        {
            var frmWait = new WaitForm(title);
            Exception callException = null;
            var result = default(T);
            _showWait = true;
            var threadStart = new ThreadStart(() =>
            {
                var start = DateTime.Now;
                try
                {
                    result = func();
                }
                catch (Exception ex)//异常回归主线程
                {
                    callException = ex;
                }
                finally
                {
                    if (DateTime.Now.Subtract(start).Milliseconds < 300)
                    {
                        _showWait = false;
                    }
                    else if (DateTime.Now.Subtract(start).Milliseconds < 500)
                    {
                        System.Threading.Thread.Sleep(300);
                    }
                    frmWait.DialogResult = DialogResult.OK;
                }
            });
            var thread = new System.Threading.Thread(threadStart);
            thread.Start();
            while (!thread.IsAlive){}
            System.Threading.Thread.Sleep(300);
            if (_showWait)
            {
                frmWait.ShowDialog();
                frmWait.Close();
            }
            if (callException != null)//主线程抛出异常
            {
                throw ExceptionHelper.GetInnerException(callException);
            }
            return result;
        }


        /// <summary>
        /// 在指定控件的中部显示等候图标
        /// </summary>
        public static void ShowInnerWait(Control parent, string msg = "请稍后…")
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(WaitUC))
                {
                    return;
                }
            }
            MethodInvoker callback = delegate
            {
                var wait = new WaitUC(msg);
                parent.Controls.Add(wait);
                wait.Width = parent.Width;
                wait.Height = parent.Height;
                wait.Top = 0;
                wait.Left = 0;
                wait.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

                parent.Controls.SetChildIndex(wait, 0);
            };
            parent.Invoke(callback);
        }

        /// <summary>
        /// 在指定控件的中部取消等候图标的显示
        /// </summary>
        public static void CloseInnerWait(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(WaitUC))
                {
                    MethodInvoker callback = delegate
                    {
                        parent.Controls.Remove(c);
                    };
                    parent.Invoke(callback);
                }
            }
        }

        /// <summary>
        /// 在指定控件的中部显示等候图标
        /// </summary>
        public static void ShowInnerWaitCircle(Control parent, string msg = "请稍后…", LoadingCircle.LoadingCircleStyle style = null)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(WaitUC))
                {
                    return;
                }
            }
            MethodInvoker callback = delegate
            {
                var circle = new LoadingCircle();
                if (style == null)
                {
                    ControlStyleHelper.SetLoadingCircle(circle);
                }
                else
                {
                    circle.Enabled = style.Enabled;
                    circle.Active = style.Active;
                    circle.InnerCircleRadius = style.InnerCircleRadius;
                    circle.OuterCircleRadius = style.OuterCircleRadius;
                    circle.NumberSpoke = style.NumberSpoke;
                    circle.BackColor = style.BackColor;
                    circle.RotationSpeed = style.RotationSpeed;
                    circle.SpokeThickness = style.SpokeThickness;
                    circle.Color = style.CircleColor;
                    circle.StylePreset = style.CircleStyle;
                }
                circle.Dock = DockStyle.Fill;
                parent.Controls.Add(circle);
                parent.Controls.SetChildIndex(circle, 0);
            };
            parent.Invoke(callback);
        }
        /// <summary>
        /// 在指定控件的中部显示等候图标
        /// </summary>
        public static void ShowInnerWaitCircle(Control parent, LoadingCircle circle, string msg = "请稍后…")
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(WaitUC))
                {
                    return;
                }
            }
            MethodInvoker callback = delegate
            {
                if (circle == null) { circle = new LoadingCircle { BackColor = Color.Transparent }; }
                circle.Dock = DockStyle.Fill;
                parent.Controls.Add(circle);
                parent.Controls.SetChildIndex(circle, 0);
            };
            parent.Invoke(callback);
        }

        /// <summary>
        /// 在指定控件的中部取消等候图标的显示
        /// </summary>
        public static void CloseInnerWaitCircle(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(LoadingCircle))
                {
                    MethodInvoker callback = delegate
                    {
                        parent.Controls.Remove(c);
                    };
                    parent.Invoke(callback);
                }
            }
        }
        /// <summary>
        /// 控件置中
        /// </summary>
        public static void CenterControl(Control ctr, Control parent)
        {
            ctr.Left = parent.ClientSize.Width > ctr.ClientSize.Width ? (parent.ClientSize.Width - ctr.ClientSize.Width) / 2 : 0;
            ctr.Top = parent.ClientSize.Height > ctr.ClientSize.Height ? (parent.ClientSize.Height - ctr.ClientSize.Height) / 2 : 0;
        }


        /// <summary>
        /// 添加必填红星
        /// </summary>
        /// <param name="ctr">要添加红星的控件</param>
        /// <param name="position">图标位置</param>
        public static void AddRedStar(Control ctr, PositionEnum position)
        {
            var lblName = ctr.Name + "Star";
            if (!ctr.Parent.Controls.ContainsKey(lblName))
            {
                var labelStar = new LabelControl();
                labelStar.ForeColor = Color.Red;
                switch (position)
                {
                    case PositionEnum.Bottom:
                        {
                            labelStar.Top = ctr.Top + ctr.Height + 2;
                            labelStar.Left = ctr.Left;
                            break;
                        }
                    case PositionEnum.Left:
                        {
                            labelStar.Top = ctr.Top + ((ctr.Height - labelStar.Height) / 2) + 3;
                            labelStar.Left = ctr.Left - 8;
                            break;
                        }
                    case PositionEnum.Right:
                        {
                            labelStar.Top = ctr.Top + ((ctr.Height - labelStar.Height) / 2) + 3;
                            labelStar.Left = ctr.Left + ctr.Width + 2;
                            break;
                        }
                    case PositionEnum.Top:
                        {
                            labelStar.Top = ctr.Top - 14;
                            labelStar.Left = ctr.Left;
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException("未实现" + position);
                        }
                }
                labelStar.Name = lblName;
                labelStar.Text = @"*";
                labelStar.ToolTip = @"此项必填";
                labelStar.Appearance.Options.UseTextOptions = true;
                labelStar.Appearance.TextOptions.VAlignment = VertAlignment.Center;

                ctr.Parent.Controls.Add(labelStar);
            }
        }

        /// <summary>
        /// 提示
        /// </summary>
        public static DialogResult ShowInfoMessage(string msg, string title = "提示", Form parent = null)
        {
            var p = parent ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
            return result;
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static DialogResult ShowWarningMessage(string msg, string title = "警告", Form parent = null)
        {
            var p = parent ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
            return result;
        }

        /// <summary>
        /// 错误
        /// </summary>
        public static DialogResult ShowErrorMessage(string msg, string title = "错误", Form parent = null)
        {
            var p = parent ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.OK;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            return result;
        }

        /// <summary>
        /// 确认
        /// </summary>
        public static DialogResult ShowConfirmMessage(string msg, string title = "确认", Form parent = null)
        {
            var p = parent ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            });
            return result;
        }

        /// <summary>
        /// 成功
        /// </summary>
        public static DialogResult ShowSuccessMessage(string msg, string title = "提示", Form parent = null)
        {
            DialogResult[] buttons = { DialogResult.OK };
            var icon = Resources.Success;
            var p = parent ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, buttons, icon, 0, MessageBoxIcon.Information);
            });
            return result;
        }


        /// <summary>
        /// 提示
        /// </summary>
        public static DialogResult ShowInfoMessage(Control ctr, string msg, string title = "提示")
        {
            var frm = ctr.FindForm();
            var p = frm ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
            return result;
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static DialogResult ShowWarningMessage(Control ctr, string msg, string title = "警告")
        {
            var frm = ctr.FindForm();
            var p = frm ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
            return result;
        }

        /// <summary>
        /// 错误
        /// </summary>
        public static DialogResult ShowErrorMessage(Control ctr, string msg, string title = "错误")
        {
            var frm = ctr.FindForm();
            var p = frm ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.OK;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            return result;
        }

        /// <summary>
        /// 确认
        /// </summary>
        public static DialogResult ShowConfirmMessage(Control ctr, string msg, string title = "确认")
        {
            var frm = ctr.FindForm();
            var p = frm ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            });
            return result;
        }

        /// <summary>
        /// 成功
        /// </summary>
        public static DialogResult ShowSuccessMessage(Control ctr, string msg, string title = "提示")
        {
            DialogResult[] buttons = { DialogResult.OK };
            var icon = Resources.Success;
            var frm = ctr.FindForm();
            var p = frm ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            var result = DialogResult.No;
            InvokeExecute(p, () =>
            {
                result = XtraMessageBox.Show(p, msg, title, buttons, icon, 0, MessageBoxIcon.Information);
            });
            return result;
        }



        /// <summary>
        /// 用户控件显示为对话框
        /// </summary>
        /// <param name="owner">父窗体</param>
        /// <param name="title">窗体标题</param>
        /// <param name="uc">用户控件</param>
        /// <param name="allowESC">是否允许ESC键关闭窗体</param>
        /// <returns>对话框结果</returns>
        public static DialogResult ShowDialog(Control uc, string title, Form owner, bool allowESC = true)
        {
            if (owner == null) { throw new ArgumentNullException(nameof(owner),@"ShowDialog owner窗体不能为null"); }
            var form = new XtraForm
            {
                Icon = owner.Icon,
                Text = title
            };
            if (allowESC)
            {
                form.KeyPreview = true;
                form.KeyUp += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        var frm = sender as XtraForm;
                        frm.DialogResult = DialogResult.Cancel;
                    }
                };
            }
            form.ClientSize = new Size(uc.Width, uc.Height);
            ControlStyleHelper.SetPopupStyle(form);
            uc.Dock = DockStyle.Fill;
            form.Controls.Add(uc);
            return form.ShowDialog(owner);
        }

        /// <summary>
        /// Invoke执行
        /// </summary>
        /// <param name="ctr">调用Invoke方法的控件</param>
        /// <param name="action">执行方法</param>
        public static void InvokeExecute(Control ctr, Action action)
        {
            if (ctr != null && ctr.InvokeRequired)
            {
                ctr.Invoke(action);
            }
            else
            {
                action();
            }
        }


        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="action">Action执行体</param>
        /// <param name="final">try,catch,finally块中执行的Action方法</param>
        public static void HandleException(Action action, Action final = null)
        {
            try
            {
                action();
            }
            catch (AppBusinessException bex)
            {
                ShowInfoMessage(bex.ErrorDescription);
            }
            catch (AppProgramException pex)
            {
                ShowErrorMessage(pex.ErrorDescription);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                ShowErrorMessage(UtilityErrors.UnHandleProgramError.GetErrorText());
            }
            finally
            {
                final?.Invoke();
            }
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="func">带返回数据的方法执行体</param>
        /// <param name="final">try,catch,finally块中执行的Action方法</param>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <returns>func调用的返回数据</returns>
        public static TResult HandleException<TResult>(Func<TResult> func, Action final = null)
        {
            try
            {
                return func();
            }
            catch (AppBusinessException bex)
            {
                ShowInfoMessage(bex.ErrorDescription);
            }
            catch (AppProgramException pex)
            {
                ShowErrorMessage(pex.ErrorDescription);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                ShowErrorMessage(UtilityErrors.UnHandleProgramError.GetErrorText());
            }
            finally
            {
                final?.Invoke();
            }
            return default(TResult);
        }

        /// <summary>
        /// 得到控件名称（只使用于窗体布局）
        /// </summary>
        /// <returns>控件名称</returns>
        public static string GetControlName<T>(Expression<Func<T, object>> expr)
        {
            var body = expr.Body.ToString();
            body = body.Substring(body.IndexOf(".", StringComparison.Ordinal) + 1);
            return $"_{body.Replace(".", "_").Replace("(", "").Replace(")", "")}";
        }
    }

}