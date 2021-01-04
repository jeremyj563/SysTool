// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

// scope: namespace
[assembly: SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "SysTool")]

// scope: type
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "type", Target = "~T:SysTool.Models.WMI.ds_user")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "type", Target = "~T:SysTool.Models.WMI.ds_computer")]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "type", Target = "~T:SysTool.Models.WMI.ds_computer")]
[assembly: SuppressMessage("Usage", "CA2237:Mark ISerializable types with serializable", Justification = "<Pending>", Scope = "type", Target = "~T:SysTool.Controls.ComputerNode")]

// scope: member
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Extensions.PutOptionsExtensions.UseDefaultUpdateOptions(System.Management.PutOptions,System.String[])")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Forms.MainForm.InitializeAsync~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Program.HandleExceptions(System.Threading.Tasks.Task)")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Program.HandleExceptions(System.Threading.Tasks.Task)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Forms.Notification.OnPaint(System.Windows.Forms.PaintEventArgs)")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:SysTool.Models.WMI.ds_user.DS_memberOf")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:SysTool.Models.WMI.ds_user.DS_uid")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:SysTool.Models.WMI.ds_computer.DS_networkAddress")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Program.StartAsync~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:SysTool.Models.WMI.ds_computer.DS_description")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:SysTool.Models.WMI.ds_computer.DS_uid")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Forms.Notification.Show(System.Type,System.Exception)")]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "member", Target = "~P:SysTool.Models.Computer.ds_computer")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Extensions.ObjectExtensions.PropertiesContain(System.Object,System.String,System.StringComparison)~System.Boolean")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Extensions.ObjectExtensions.PropertiesContain(System.Object,System.String,System.StringComparison)~System.Boolean")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~P:SysTool.Models.Computer.ds_computer")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Models.Computer.#ctor(SysTool.Models.WMI.ds_computer)")]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Forms.SplashForm.this_MouseDown(System.Object,System.Windows.Forms.MouseEventArgs)")]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Forms.SplashForm.this_MouseMove(System.Object,System.Windows.Forms.MouseEventArgs)")]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Forms.SplashForm.this_MouseUp(System.Object,System.Windows.Forms.MouseEventArgs)")]
